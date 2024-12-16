using BL.Services;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using OpcUaClient.Helpers;

namespace BL.Daemons
{
    public class OpcUaClientDaemon : BackgroundService
    {
        private readonly ILogger<OpcUaClientDaemon> _logger;

        public OpcUaClientDaemon(ILogger<OpcUaClientDaemon> logger)
        {
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            await _startOpcUaClientDaemon(stoppingToken);
        }

        private async Task _startOpcUaClientDaemon(CancellationToken cancellationToken)
        {
            _logger.LogInformation("OPC UA Daemon routine started.");

            MonitoredItemsHelper monitoredItemsHelper = new MonitoredItemsHelper();
            await monitoredItemsHelper.AddHandlersToMonitoredItems();

            ConnectionServices connectionServices = new ConnectionServices();

            while (true)
            {
                connectionServices.InvertLiveBitsAsync();
                await Task.Delay(2000, cancellationToken);
            }
        }
    }
}
