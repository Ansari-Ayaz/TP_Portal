using System.Collections.Generic;

namespace TP_API.Models.TransectionModels
{
    public class QuesData
    {
        public long? QId { get; set; }
        public string QuestionText { get; set; }
        public List<OptData> Options { get; set; }
    }
}
