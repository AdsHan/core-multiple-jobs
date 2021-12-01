using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using MultipleJobs.API.Jobs;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace MultipleJobs.API.Services
{
    public class ImportBackgroundService : BackgroundService, IImportBackgroundService
    {
        private List<Task> jobsToRun = new List<Task>();

        private readonly ILogger<IImportBackgroundService> _logger;

        public ImportBackgroundService(ILogger<IImportBackgroundService> logger)
        {
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {

            var j1 = new Job1(_logger);
            jobsToRun.Add(Task.Run(async () => await j1.DoWork(stoppingToken)));

            var j2 = new Job2(_logger);
            jobsToRun.Add(Task.Run(async () => await j2.DoWork(stoppingToken)));

        }

        public Task StartJobs(CancellationToken token = default) => base.StartAsync(token);
        public Task StopJobs(CancellationToken token = default) => base.StopAsync(token);

    }
}
