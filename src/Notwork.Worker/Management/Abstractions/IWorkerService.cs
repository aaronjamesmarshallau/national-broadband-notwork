using System.Threading.Tasks;

namespace Notwork.Worker.Management.Abstractions
{
    public interface IWorkerService
    {
        Task StartAsync();
    }
}