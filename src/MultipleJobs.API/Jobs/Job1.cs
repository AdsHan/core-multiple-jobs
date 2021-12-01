using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace MultipleJobs.API.Jobs
{
    public class Job1 : IJob
    {
        private readonly ILogger _logger;

        private int executionCount = 0;

        public Job1(ILogger logger)
        {
            _logger = logger;
        }

        public async Task DoWork(CancellationToken token)
        {
            while (!token.IsCancellationRequested)
            {
                try
                {
                    var count = Interlocked.Increment(ref executionCount);

                    _logger.LogInformation("Job 1 {Count}", count);


                    await Task.Delay(2000, token);
                }
                catch (TaskCanceledException)
                {
                    _logger.LogInformation("Job 1 cancelado!");
                    break;
                }

            }

            _logger.LogInformation("Job 1 finalizado!");
        }

    }
}
