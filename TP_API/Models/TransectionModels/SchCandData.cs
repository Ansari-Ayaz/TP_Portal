using System;
using System.Collections.Generic;

namespace TP_API.Models.TransectionModels
{
    public class SchCandData
    {
        public long TestId { get; set; }
        public string TestName { get; set; }
        public long UserId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        
        public List<CandData> Candidates { get; set; }
    }
}
