using OpcUaClient.ConcreteOpcUaClients;
using OpcUaClient;
using BL.Services;
using DAL.Data;
using DAL.Models;

namespace BL.Handlers
{
    internal class ScanDataReadyHandler : NewDataReadyAbstractHandler
    {
        protected override AbstractOpcUaClient opcUaClient { get; } = ScrewOpcUaClient.Instance;
        protected override string RootNodeId { get; } = @"ns=3;s=""dataScanOPC""";


        protected internal override async Task SaveRecord()
        {
            MyDbContext dbContext = new MyDbContext();

            PartServices partServices = new PartServices();

            string serialNumber = await opcUaClient.ReadValueAsync(RootNodeId + @".""records""[0].""serialNumber""", new string(""));

            dbContext.ScanProcessData.Add(new ScanProcessData()
            {
                SerialNumber = serialNumber,
                SerialNumberProduct = await opcUaClient.ReadValueAsync(RootNodeId + @".""records""[0].""serialNumberProduct""", new string("")),
                FFF = await opcUaClient.ReadValueAsync(RootNodeId + @".""records""[0].""FFF""", new string("")),
                YY = await opcUaClient.ReadValueAsync(RootNodeId + @".""records""[0].""YY""", new string("")),
                PartIdent = await opcUaClient.ReadValueAsync(RootNodeId + @".""records""[0].""partIdent""", new string("")),
                PlantCode = await opcUaClient.ReadValueAsync(RootNodeId + @".""records""[0].""plantCode""", new string("")),
                CodeQuality = await opcUaClient.ReadValueAsync(RootNodeId + @".""records""[0].""codeQuality""", new string("")),
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
