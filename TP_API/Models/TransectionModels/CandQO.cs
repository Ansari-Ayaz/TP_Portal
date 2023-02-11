using System.Collections.Generic;

namespace TP_API.Models.TransectionModels
{
    public class CandQO
    {
        public long? QId { get; set; }
        public string QuestionText { get; set; }
        public List<CandO> Options { get; set; }
    }
}
