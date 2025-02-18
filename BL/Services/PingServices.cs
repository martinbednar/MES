using System.Net.NetworkInformation;

namespace BL.Services
{
    internal class PingServices
    {
        internal async Task<bool> PingHost(string nameOrAddress)
        {
            try
            {
                using (Ping pinger = new Ping())
                {
                    PingReply reply = await pinger.SendPingAsync(nameOrAddress);
                    return reply.Status == IPStatus.Success;
                }
            }
            catch (PingException)
            {
                return false;
            }
        }
    }
}
