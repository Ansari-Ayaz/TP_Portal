using System.Collections.Generic;
using TP_API.Models.DBModels;

namespace TP_API.Models.TransectionModels
{
    public class CandTQO
    {
        public long LoggedInUser { get; set; }
        public long TestId { get; set; }

        public List<CandQO> Questions { get; set; }
        public TestDetail TDetail { get; set; }
    }
}
