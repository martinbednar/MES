namespace OpcUaClient.ConcreteOpcUaClients
{
    public sealed class ScrewOpcUaClient : AbstractOpcUaClient
    {
        protected override string PlcIpAddress { get; } = "192.168.111.50";
        public override string LiveBitNode { get; } = @"ns=3;s=""screwSystemStateDB"".""i"".""liveBit""";
        public override List<string> MonitoredItems { get; } = new List<string> {
            @"ns=3;s=""dataAutoScrewOPC"".""o"".""newDataReady""",
            @"ns=3;s=""dataNGOPC"".""o"".""newDataReady""",
            @"ns=3;s=""dataFFOPC"".""o"".""newDataReady""",
            @"ns=3;s=""dataManuScrewOPC"".""o"".""newDataReady""",
            @"ns=3;s=""dataConductOPC"".""o"".""newDataReady""",
            @"ns=3;s=""dataScanOPC"".""o"".""newDataReady"""
        };


        private static readonly object createLock = new object();
        private static ScrewOpcUaClient? instance = null;
        public static ScrewOpcUaClient Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (createLock)
                    {
                        if (instance == null)
                        {
                            instance = new ScrewOpcUaClient();
                        }
                    }
                }
                return instance;
            }
        }

        private ScrewOpcUaClient()
        {
            CreateConfiguration();
            CreateSession();
        }
    }
}
