using System.Threading;
using System.Threading.Tasks;

namespace MultipleJobs.API.Jobs
{
    public interface IJob
    {
        Task DoWork(CancellationToken token);
    }
}
