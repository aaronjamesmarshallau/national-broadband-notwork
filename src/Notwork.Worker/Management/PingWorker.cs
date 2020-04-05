using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Notwork.Worker.Configuration;
using Notwork.Worker.Management.Abstractions;

namespace Notwork.Worker.Management
{
    /// <summary>
    /// Worker responsible for just pinging the API.
    /// </summary>
    public class PingWorker : IntervalService, IDisposable
    {
        private readonly string _apiHost;
        private readonly int _apiPort;

        private readonly WebClient _client;
        
        /// <summary>
        /// Creates a new instance of the <see cref="PingWorker"/>.
        /// </summary>
        /// <param name="token">The <see cref="CancellationToken"/>.</param>
        /// <param name="config">The <see cref="EnvironmentConfig"/>.</param>
        public PingWorker(CancellationToken token, EnvironmentConfig config) : base(token)
        {
            _apiHost = config.ApiHost;
            _apiPort = config.ApiPort;
            
            _client = new WebClient();
            _client.BaseAddress = $"https://{_apiHost}:{_apiPort}/";
        }

        /// <summary>
        /// Poll every 10 seconds.
        /// </summary>
        protected override TimeSpan Interval => TimeSpan.FromSeconds(10);
        
        protected override async Task ProcessAsync()
        {
            var response = await _client.DownloadStringTaskAsync("/api/ping");
            Console.WriteLine(response);
        }

        public void Dispose()
        {
            _client.Dispose();
        }
    }
}