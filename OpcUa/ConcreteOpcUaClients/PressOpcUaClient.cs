namespace OpcUaClient.ConcreteOpcUaClients
{
    public sealed class PressOpcUaClient : AbstractOpcUaClient
    {
        protected override string PlcIpAddress { get; } = "192.168.111.30";
        public override string LiveBitNode { get; } = @"ns=3;s=""pressSystemStateDB"".""i"".""liveBit""";
        public override List<string> MonitoredItems { get; } = new List<string> {
            @"ns=3;s=""dataPressOPC"".""o"".""newDataReady""",
            @"ns=3;s=""dataReworkOPC"".""o"".""newDataReady"""
        };


        private static readonly object createLock = new object();
        private static PressOpcUaClient? instance = null;
        public static PressOpcUaClient Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (createLock)
                    {
                        if (instance == null)
                        {
                            instance = new PressOpcUaClient();
                        }
                    }
                }
                return instance;
            }
        }

        private PressOpcUaClient()
        {
            CreateConfiguration();
            CreateSession();
        }
    }
}
