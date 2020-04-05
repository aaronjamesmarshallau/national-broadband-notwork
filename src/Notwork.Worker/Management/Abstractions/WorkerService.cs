using System.Threading;
using System.Threading.Tasks;
using Notwork.Worker.Management.Abstractions;

namespace Notwork.Worker.Management.Abstractions
{
    public abstract class WorkerService : IWorkerService
    {
        protected readonly CancellationToken Token;

        protected WorkerService(CancellationToken token)
        {
            Token = token;
        }

        public abstract Task StartAsync();
    }
}