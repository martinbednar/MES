using BL.Handlers;

namespace BL.Mappers
{
    internal sealed class MonitoredItemsMapper
    {
        internal NewDataReadyAbstractHandler GetNewDataReadyHandler(string monitoredItemNode)
        {
            switch (monitoredItemNode)
            {
                case @"ns=3;s=""dataPressOPC"".""o"".""newDataReady""":
                    return new PressDataReadyHandler();
                case @"ns=3;s=""dataReworkOPC"".""o"".""newDataReady""":
                    return new PressReworkDataReadyHandler();
                case @"ns=3;s=""dataAutoScrewOPC"".""o"".""newDataReady""":
                    return new AutoScrewDataReadyHandler();
                case @"ns=3;s=""dataNGOPC"".""o"".""newDataReady""":
                    return new NgAutoScrewDataReadyHandler();
                case @"ns=3;s=""dataFFOPC"".""o"".""newDataReady""":
                    return new FitAndFunctionDataReadyHandler();
                case @"ns=3;s=""dataManuScrewOPC"".""o"".""newDataReady""":
                    return new ManualScrewDataReadyHandler();
                case @"ns=3;s=""dataConductOPC"".""o"".""newDataReady""":
                    return new ConductDataReadyHandler();
                case @"ns=3;s=""dataScanOPC"".""o"".""newDataReady""":
                    return new ScanDataReadyHandler();
                default:
                    return new UnknownDataReadyHandler();
            }
        }
    }
}
