using System;
using System.Threading;
using System.Threading.Tasks;

namespace Notwork.Worker.Management.Abstractions
{
    public abstract class IntervalService : WorkerService
    {
        protected abstract TimeSpan Interval { get; }
        protected int IterationCount = 0;
        protected int SuccessfulIterations = 0;
        protected int FailedIterations = 0;

        public IntervalService(CancellationToken token) : base(token)
        {
        }

        protected abstract Task ProcessAsync();

        public override async Task StartAsync()
        {
            while (!Token.IsCancellationRequested)
            {
                IterationCount++;
                try
                {
                    await ProcessAsync();
                }
                catch (Exception ex)
                {
                    FailedIterations++;
                    Console.WriteLine(ex);
                }

                SuccessfulIterations++;
                await Task.Delay(Interval, Token);
            }
        }
    }
}