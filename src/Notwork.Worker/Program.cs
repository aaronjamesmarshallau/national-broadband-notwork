using System;
using System.Threading.Tasks;
using Notwork.Worker.Management;

namespace Notwork.Worker
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var workerManager = new WorkerManager(args);

            workerManager.Begin();
            await workerManager.CloseRequestedAsync();
        }
    }
}
