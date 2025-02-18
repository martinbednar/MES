namespace BL.DTOs
{
    public class StationStatusDTO
    {
        public required int Id { get; set; }
        public required string Name { get; set; }
        public required string IpAddress { get; set; }
        public required bool IsAlive { get; set; }
        public required StationStatusEnum Status { get; set; }
    }
}
