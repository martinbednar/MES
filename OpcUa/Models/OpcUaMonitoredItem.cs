using Opc.Ua.Client;

namespace OpcUaClient.Models
{
    public class OpcUaMonitoredItem
    {
        public required string NodeId { get; set; }
        public required MonitoredItemNotificationEventHandler Handler { get; set; }
    }
}
