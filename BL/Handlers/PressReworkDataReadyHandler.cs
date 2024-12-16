using OpcUaClient.ConcreteOpcUaClients;
using OpcUaClient;
using BL.Services;
using DAL.Data;
using DAL.Models;

namespace BL.Handlers
{
    internal class PressReworkDataReadyHandler : NewDataReadyAbstractHandler
    {
        protected override AbstractOpcUaClient opcUaClient { get; } = PressOpcUaClient.Instance;
        protected override string RootNodeId { get; } = @"ns=3;s=""dataReworkOPC""";


        protected internal override async Task SaveRecord()
        {
            MyDbContext dbContext = new MyDbContext();

            PartServices partServices = new PartServices();

            string serialNumber = await opcUaClient.ReadValueAsync(RootNodeId + @".""records""[0].""serialNumber""", new string(""));

            dbContext.PressingReworkProcessData.Add(new PressingReworkProcessData()
            {
                SerialNumber = serialNumber,
                Message = await opcUaClient.ReadValueAsync(RootNodeId + @".""records""[0].""message""", new string("")),
                Rework1 = await opcUaClient.ReadValueAsync(RootNodeId + @".""records""[0].""rework1""", new bool()),
                Rework2 = await opcUaClient.ReadValueAsync(RootNodeId + @".""records""[0].""rework2""", new bool()),
                Rework3 = await opcUaClient.ReadValueAsync(RootNodeId + @".""records""[0].""rework3""", new bool()),
                In1 = await opcUaClient.ReadValueAsync(RootNodeId + @".""records""[0].""sensor1""", new bool()),
                In2 = await opcUaClient.ReadValueAsync(RootNodeId + @".""records""[0].""sensor2""", new bool()),
                In3 = await opcUaClient.ReadValueAsync(RootNodeId + @".""records""[0].""sensor3""", new bool()),
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
