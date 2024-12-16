using Opc.Ua.Client;
using OpcUaClient;

namespace BL.Handlers
{
    internal abstract class NewDataReadyAbstractHandler
    {
        protected abstract AbstractOpcUaClient opcUaClient { get; }
        protected abstract string RootNodeId { get; }

        protected internal async void NewDataReady(MonitoredItem item, MonitoredItemNotificationEventArgs e)
        {
            foreach (var value in item.DequeueValues())
            {
                bool newDataReady = (bool)value.Value;
                Console.WriteLine(@"{0}: ""o"".""newDataReady"": {1}, {2}, {3}", item.DisplayName, newDataReady, value.SourceTimestamp, value.StatusCode);
                
                if (newDataReady)
                {
                    await opcUaClient.WriteValueAsync(RootNodeId + @".""i"".""busy""", true);
                    await SaveRecord();
                    await opcUaClient.WriteValueAsync(RootNodeId + @".""i"".""busy""", false);
                    await opcUaClient.WriteValueAsync(RootNodeId + @".""i"".""readDone""", true);
                }
                else
                {
                    await opcUaClient.WriteValuesAsync(new List<string>()
                        {
                            RootNodeId + @".""i"".""busy""",
                            RootNodeId + @".""i"".""readDone"""
                        },
                    false);
                }
            }
        }

        protected internal abstract Task SaveRecord();
    }
}
