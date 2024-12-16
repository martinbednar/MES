using BL.Mappers;
using OpcUaClient.ConcreteOpcUaClients;
using OpcUaClient.Models;

namespace OpcUaClient.Helpers
{
    internal class MonitoredItemsHelper
    {
        internal List<OpcUaMonitoredItem> GetOpcUaSubscriptions(AbstractOpcUaClient opcUaClient)
        {
            MonitoredItemsMapper monitoredItemsMapper = new MonitoredItemsMapper();

            List<OpcUaMonitoredItem> opcUaMonitoredItems = new List<OpcUaMonitoredItem>();

            foreach (string monitoredItem in opcUaClient.MonitoredItems)
            {
                opcUaMonitoredItems.Add(new OpcUaMonitoredItem()
                {
                    NodeId = monitoredItem,
                    Handler = monitoredItemsMapper.GetNewDataReadyHandler(monitoredItem).NewDataReady
                });
            }
            return opcUaMonitoredItems;
        }

        internal void RegisterMonitoredItems(AbstractOpcUaClient opcUaClient, List<OpcUaMonitoredItem> opcUaMonitoredItems)
        {
            while (true)
            {
                try
                {
                    opcUaClient.AddListeners(opcUaMonitoredItems);
                    break; // Exit the loop when listeners successfully added.
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine("OPC UA Client: Failed to register monitored items.");
                }
            }
        }

        internal async Task AddHandlersToMonitoredItems()
        {
            List<OpcUaMonitoredItem> pressOpcUaMonitoredItems = GetOpcUaSubscriptions(PressOpcUaClient.Instance);
            List<OpcUaMonitoredItem> screwOpcUaMonitoredItems = GetOpcUaSubscriptions(ScrewOpcUaClient.Instance);

            await Task.Delay(1000);

            RegisterMonitoredItems(PressOpcUaClient.Instance, pressOpcUaMonitoredItems);
            RegisterMonitoredItems(ScrewOpcUaClient.Instance, screwOpcUaMonitoredItems);
        }
    }
}
