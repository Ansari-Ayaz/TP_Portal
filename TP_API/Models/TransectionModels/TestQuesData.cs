using System.Collections.Generic;
using TP_API.Models.DBModels;

namespace TP_API.Models.TransectionModels
{
    public class TestQuesData
    {
        public long LoggedInUser { get; set; }
        public long TestId { get; set; }

        public List<QuesData> Questions { get; set; }
        public TestDetail TDetail { get; set; }
        
    }
}
