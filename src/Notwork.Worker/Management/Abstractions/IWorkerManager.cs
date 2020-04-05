using System.Threading.Tasks;

namespace Notwork.Worker.Management.Abstractions
{
    public interface IWorkerManager
    {
        /// <summary>
        /// Starts the worker manager.
        /// </summary>
        void Begin();

        /// <summary>
        /// Awaits a close being requested by the worker manager.
        /// </summary>
        Task CloseRequestedAsync();
    }
}