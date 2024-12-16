using OpcUaClient.ConcreteOpcUaClients;
using OpcUaClient;
using BL.Services;
using DAL.Data;
using DAL.Models;

namespace BL.Handlers
{
    internal class NgAutoScrewDataReadyHandler : NewDataReadyAbstractHandler
    {
        protected override AbstractOpcUaClient opcUaClient { get; } = ScrewOpcUaClient.Instance;
        protected override string RootNodeId { get; } = @"ns=3;s=""dataNGOPC""";


        protected internal override async Task SaveRecord()
        {
            MyDbContext dbContext = new MyDbContext();

            PartServices partServices = new PartServices();

            string serialNumber = await opcUaClient.ReadValueAsync(RootNodeId + @".""records""[0].""serialNumber""", new string(""));

            dbContext.NgAutoScrewingProcessData.Add(new NgAutoScrewingProcessData()
            {
                SerialNumber = serialNumber,
                Message = await opcUaClient.ReadValueAsync(RootNodeId + @".""records""[0].""message""", new string("")),
                DateTime = new DateTime(
                        year: await opcUaClient.ReadValueAsync(RootNodeId + @".""records""[0].""dateTime"".""YEAR""", new UInt16()),
                        month: await opcUaClient.ReadValueAsync(RootNodeId + @".""records""[0].""dateTime"".""MONTH""", new Byte()),
                        day: await opcUaClient.ReadValueAsync(RootNodeId + @".""records""[0].""dateTime"".""DAY""", new Byte()),
                        hour: await opcUaClient.ReadValueAsync(RootNodeId + @".""records""[0].""dateTime"".""HOUR""", new Byte()),
                        minute: await opcUaClient.ReadValueAsync(RootNodeId + @".""records""[0].""dateTime"".""MINUTE""", new Byte()),
                        second: await opcUaClient.ReadValueAsync(RootNodeId + @".""records""[0].""dateTime"".""SECOND""", new Byte()),
                        millisecond: (int)Math.Round((double)(await opcUaClient.ReadValueAsync(RootNodeId + @".""records""[0].""dateTime"".""NANOSECOND""", new UInt32()) / 1000000), 0)
                    ),
                PartId = partServices.GetPart(serialNumber).Id
            });
            dbContext.SaveChanges();
        }
    }
}
