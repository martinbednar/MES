using OpcUaClient.ConcreteOpcUaClients;
using OpcUaClient;

namespace BL.Handlers
{
    internal class UnknownDataReadyHandler : NewDataReadyAbstractHandler
    {
        protected override AbstractOpcUaClient opcUaClient { get; } = ScrewOpcUaClient.Instance;
        protected override string RootNodeId { get; } = "";


        protected internal override async Task SaveRecord()
        {
            await Task.CompletedTask;
        }
    }
}
