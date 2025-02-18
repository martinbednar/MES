using BL.DTOs;

namespace BL.Services
{
    public class StationStatusServices
    {
        private List<StationStatusDTO> stations = new List<StationStatusDTO>()
        {
            new StationStatusDTO() { Id = 1, Name = "Pressing Station", IpAddress = "192.168.111.30", IsAlive = false, Status = StationStatusEnum.None },
            new StationStatusDTO() { Id = 2, Name = "Screwing Station", IpAddress = "192.168.111.50", IsAlive = false, Status = StationStatusEnum.None }
        };

        private async Task UpdateStationsIsAlive()
        {
            PingServices pingServices = new PingServices();
            foreach (var station in stations)
            {
                station.IsAlive = await pingServices.PingHost(station.IpAddress);
            }
        }

        public async Task<List<StationStatusDTO>> GetStationsStatus()
        {
            await UpdateStationsIsAlive();
            return stations;
        }

        public async Task<StationStatusDTO?> GetStationStatus(int stationId)
        {
            await UpdateStationsIsAlive();
            return stations.FirstOrDefault(s => s.Id == stationId);
        }
    }
}
