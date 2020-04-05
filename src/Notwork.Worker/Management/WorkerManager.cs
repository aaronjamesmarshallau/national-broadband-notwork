using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Notwork.Worker.Management.Abstractions;

namespace Notwork.Worker.Management
{
    public sealed class WorkerManager : IWorkerManager
    {
        private const int PollingIntervalMilliseconds = 500;
        private bool _closeRequested;

        public WorkerManager(string[] arguments)
        {
            _closeRequested = false;
        }
        
        public void Begin()
        {
            var workersToStart = new List<WorkerService>();
        }

        public async Task CloseRequestedAsync()
        {
            while (!_closeRequested)
            {
                await Task.Delay(TimeSpan.FromMilliseconds(PollingIntervalMilliseconds));
            }
        }
    }
}