using System.Collections.Generic;

namespace TP_API.Models.TransectionModels
{
    public class CandTestSubmit
    {
        public long TestId { get; set; }
        public long CandId { get; set; }
        public long ScheduleId { get; set; }
        public List<CandQOSubmit> QOs { get; set; }
    }
}
