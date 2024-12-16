using BL.Services;
using DAL.Data;
using DAL.Models;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using OpcUaClient;
using OpcUaClient.ConcreteOpcUaClients;

namespace BL.Handlers
{
    internal class FitAndFunctionDataReadyHandler : NewDataReadyAbstractHandler
    {
        protected override AbstractOpcUaClient opcUaClient { get; } = ScrewOpcUaClient.Instance;
        protected override string RootNodeId { get; } = @"ns=3;s=""dataFFOPC""";


        protected internal override async Task SaveRecord()
        {
            MyDbContext dbContext = new MyDbContext();

            PartServices partServices = new PartServices();

            string serialNumber = await opcUaClient.ReadValueAsync(RootNodeId + @".""records""[0].""serialNumber""", new string(""));

            EntityEntry<FitAndFunctionProcessData> fitAndFunctionProcessData = dbContext.FitAndFunctionProcessData.Add(new FitAndFunctionProcessData()
            {
                SerialNumber = serialNumber,
                OK = await opcUaClient.ReadValueAsync(RootNodeId + @".""records""[0].""OK""", new bool()),
                NOK = await opcUaClient.ReadValueAsync(RootNodeId + @".""records""[0].""NOK""", new bool()),
                OverallStatus = (StatusEnum)await opcUaClient.ReadValueAsync(RootNodeId + @".""records""[0].""status""", new UInt16()),
                LeftOK = await opcUaClient.ReadValueAsync(RootNodeId + @".""records""[0].""leftOK""", new bool()),
                LeftNOK = await opcUaClient.ReadValueAsync(RootNodeId + @".""records""[0].""leftNOK""", new bool()),
                LeftStatus = (StatusEnum)await opcUaClient.ReadValueAsync(RootNodeId + @".""records""[0].""leftStatus""", new UInt16()),
                RightOK = await opcUaClient.ReadValueAsync(RootNodeId + @".""records""[0].""rightOK""", new bool()),
                RightNOK = await opcUaClient.ReadValueAsync(RootNodeId + @".""records""[0].""rightNOK""", new bool()),
                RightStatus = (StatusEnum)await opcUaClient.ReadValueAsync(RootNodeId + @".""records""[0].""rightStatus""", new UInt16()),
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
                Measurements = new List<FitAndFunctionMeasurement>(),
                PartId = partServices.GetPart(serialNumber).Id
            });
            dbContext.SaveChanges();


            dbContext.FitAndFunctionMeasurements.AddRange(new List<FitAndFunctionMeasurement>()
            {
                new FitAndFunctionMeasurement()
                {
                    Min = await opcUaClient.ReadValueAsync(RootNodeId + @".""records""[0].""min1""", new float()),
                    Value = await opcUaClient.ReadValueAsync(RootNodeId + @".""records""[0].""value1""", new float()),
                    Max = await opcUaClient.ReadValueAsync(RootNodeId + @".""records""[0].""max1""", new float()),
                    OK = await opcUaClient.ReadValueAsync(RootNodeId + @".""records""[0].""OK1""", new bool()),
                    NOK = await opcUaClient.ReadValueAsync(RootNodeId + @".""records""[0].""NOK1""", new bool()),
                    Status = (StatusEnum)await opcUaClient.ReadValueAsync(RootNodeId + @".""records""[0].""status1""", new UInt16()),
                    FitAndFunctionId = fitAndFunctionProcessData.Entity.Id
                },
                new FitAndFunctionMeasurement()
                {
                    Min = await opcUaClient.ReadValueAsync(RootNodeId + @".""records""[0].""min2""", new float()),
                    Value = await opcUaClient.ReadValueAsync(RootNodeId + @".""records""[0].""value2""", new float()),
                    Max = await opcUaClient.ReadValueAsync(RootNodeId + @".""records""[0].""max2""", new float()),
                    OK = await opcUaClient.ReadValueAsync(RootNodeId + @".""records""[0].""OK2""", new bool()),
                    NOK = await opcUaClient.ReadValueAsync(RootNodeId + @".""records""[0].""NOK2""", new bool()),
                    Status = (StatusEnum)await opcUaClient.ReadValueAsync(RootNodeId + @".""records""[0].""status2""", new UInt16()),
                    FitAndFunctionId = fitAndFunctionProcessData.Entity.Id
                },
                new FitAndFunctionMeasurement()
                {
                    Min = await opcUaClient.ReadValueAsync(RootNodeId + @".""records""[0].""min3""", new float()),
                    Value = await opcUaClient.ReadValueAsync(RootNodeId + @".""records""[0].""value3""", new float()),
                    Max = await opcUaClient.ReadValueAsync(RootNodeId + @".""records""[0].""max3""", new float()),
                    OK = await opcUaClient.ReadValueAsync(RootNodeId + @".""records""[0].""OK3""", new bool()),
                    NOK = await opcUaClient.ReadValueAsync(RootNodeId + @".""records""[0].""NOK3""", new bool()),
                    Status = (StatusEnum)await opcUaClient.ReadValueAsync(RootNodeId + @".""records""[0].""status3""", new UInt16()),
                    FitAndFunctionId = fitAndFunctionProcessData.Entity.Id
                },
                new FitAndFunctionMeasurement()
                {
                    Min = await opcUaClient.ReadValueAsync(RootNodeId + @".""records""[0].""min4""", new float()),
                    Value = await opcUaClient.ReadValueAsync(RootNodeId + @".""records""[0].""value4""", new float()),
                    Max = await opcUaClient.ReadValueAsync(RootNodeId + @".""records""[0].""max4""", new float()),
                    OK = await opcUaClient.ReadValueAsync(RootNodeId + @".""records""[0].""OK4""", new bool()),
                    NOK = await opcUaClient.ReadValueAsync(RootNodeId + @".""records""[0].""NOK4""", new bool()),
                    Status = (StatusEnum)await opcUaClient.ReadValueAsync(RootNodeId + @".""records""[0].""status4""", new UInt16()),
                    FitAndFunctionId = fitAndFunctionProcessData.Entity.Id
                },
                new FitAndFunctionMeasurement()
                {
                    Min = await opcUaClient.ReadValueAsync(RootNodeId + @".""records""[0].""min5""", new float()),
                    Value = await opcUaClient.ReadValueAsync(RootNodeId + @".""records""[0].""value5""", new float()),
                    Max = await opcUaClient.ReadValueAsync(RootNodeId + @".""records""[0].""max5""", new float()),
                    OK = await opcUaClient.ReadValueAsync(RootNodeId + @".""records""[0].""OK5""", new bool()),
                    NOK = await opcUaClient.ReadValueAsync(RootNodeId + @".""records""[0].""NOK5""", new bool()),
                    Status = (StatusEnum)await opcUaClient.ReadValueAsync(RootNodeId + @".""records""[0].""status5""", new UInt16()),
                    FitAndFunctionId = fitAndFunctionProcessData.Entity.Id
                }
            });
            dbContext.SaveChanges();
        }
    }
}
