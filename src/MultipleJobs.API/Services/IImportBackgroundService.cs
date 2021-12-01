using System.Threading;
using System.Threading.Tasks;

namespace MultipleJobs.API.Services
{
    public interface IImportBackgroundService
    {
        Task StartJobs(CancellationToken token = default);
        Task StopJobs(CancellationToken token = default);
    }
}
