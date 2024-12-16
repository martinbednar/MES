using OpcUaClient.ConcreteOpcUaClients;
using OpcUaClient;
using DAL.Data;
using DAL.Models;
using BL.Services;

namespace BL.Handlers
{
    internal class ConductDataReadyHandler : NewDataReadyAbstractHandler
    {
        protected override AbstractOpcUaClient opcUaClient { get; } = ScrewOpcUaClient.Instance;
        protected override string RootNodeId { get; } = @"ns=3;s=""dataConductOPC""";


        protected internal override async Task SaveRecord()
        {
            MyDbContext dbContext = new MyDbContext();

            PartServices partServices = new PartServices();

            string serialNumber = await opcUaClient.ReadValueAsync(RootNodeId + @".""records""[0].""serialNumber""", new string(""));

            dbContext.ConductivityProcessData.Add(new ConductivityProcessData()
            {
                SerialNumber = serialNumber,
                Min = await opcUaClient.ReadValueAsync(RootNodeId + @".""records""[0].""min""", new float()),
                Value = await opcUaClient.ReadValueAsync(RootNodeId + @".""records""[0].""value""", new float()),
                Max = await opcUaClient.ReadValueAsync(RootNodeId + @".""records""[0].""max""", new float()),
                OK = await opcUaClient.ReadValueAsync(RootNodeId + @".""records""[0].""OK""", new bool()),
                NOK = await opcUaClient.ReadValueAsync(RootNodeId + @".""records""[0].""NOK""", new bool()),
                Status = (StatusEnum)await opcUaClient.ReadValueAsync(RootNodeId + @".""records""[0].""status""", new UInt16()),
                DateTimeStarted = new DateTime(
                        year: await opcUaClient.ReadValueAsync(RootNodeId + @".""records""[0].""dateTimeStart"".""YEAR""", new UInt16()),
                        month: await opcUaClient.ReadValueAsync(RootNodeId + @".""records""[0].""dateTimeStart"".""MONTH""", new Byte()),
                        day: await opcUaClient.ReadValueAsync(RootNodeId + @".""records""[0].""dateTimeStart"".""DAY""", new Byte()),
                        hour: await opcUaClient.ReadValueAsync(RootNodeId + @".""records""[0].""dateTimeStart"".""HOUR""", new Byte()),
                        minute: await opcUaClient.ReadValueAsync(RootNodeId + @".""records""[0].""dateTimeStart"".""MINUTE""", new Byte()),
                        second: await opcUaClient.ReadValueAsync(RootNodeId + @".""records""[0].""dateTimeStart"".""SECOND""", new Byte()),
                        millisecond: (int)Math.Round((double)(await opcUaClient.ReadValueAsync(RootNodeId + @".""records""[0].""dateTimeStart"".""NANOSECOND""", new UInt32()) / 1000000), 0)
                    ),
                DateTimeFinished = new DateTime(
                        year: await opcUaClient.ReadValueAsync(RootNodeId + @".""records""[0].""dateTimeFinished"".""YEAR""", new UInt16()),
                        month: await opcUaClient.ReadValueAsync(RootNodeId + @".""records""[0].""dateTimeFinished"".""MONTH""", new Byte()),
                        day: await opcUaClient.ReadValueAsync(RootNodeId + @".""records""[0].""dateTimeFinished"".""DAY""", new Byte()),
                        hour: await opcUaClient.ReadValueAsync(RootNodeId + @".""records""[0].""dateTimeFinished"".""HOUR""", new Byte()),
                        minute: await opcUaClient.ReadValueAsync(RootNodeId + @".""records""[0].""dateTimeFinished"".""MINUTE""", new Byte()),
                        second: await opcUaClient.ReadValueAsync(RootNodeId + @".""records""[0].""dateTimeFinished"".""SECOND""", new Byte()),
                        millisecond: (int)Math.Round((double)(await opcUaClient.ReadValueAsync(RootNodeId + @".""records""[0].""dateTimeStart"".""NANOSECOND""", new UInt32()) / 1000000), 0)
                    ),
                PartId = partServices.GetPart(serialNumber).Id
            });
            dbContext.SaveChanges();
        }
    }
}
