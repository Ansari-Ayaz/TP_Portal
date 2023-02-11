namespace TP_API.Models.TransectionModels
{
    public class CandData
    {
        public string Email { get; set; }
        public string Name { get; set; }
        public string? Password { get; set; }
        public long TestId { get; set; }
        public string TestName { get; set; }
        public long CId { get; set; }
        public long ScheduleId { get; set; }
    }
}
