using OpcUaClient;
using OpcUaClient.ConcreteOpcUaClients;

namespace BL.Services
{
    public class ConnectionServices
    {
        private async Task SetLiveBitAsync(AbstractOpcUaClient opcUaClient, bool value)
        {
            await opcUaClient.WriteValueAsync(opcUaClient.LiveBitNode, value);
        }

        public async Task InvertLiveBitAsync(AbstractOpcUaClient opcUaClient)
        {
            bool liveBitCurrectValue = await opcUaClient.ReadValueAsync(opcUaClient.LiveBitNode, new bool());
            await SetLiveBitAsync(opcUaClient, !liveBitCurrectValue);
        }

        public async void InvertLiveBitsAsync()
        {
            await InvertLiveBitAsync(PressOpcUaClient.Instance);
            await InvertLiveBitAsync(ScrewOpcUaClient.Instance);
        }
    }
}
