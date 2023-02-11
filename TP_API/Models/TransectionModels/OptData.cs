using System.Collections.Generic;
using TP_API.Models.DBModels;

namespace TP_API.Models.TransectionModels
{
    public class OptData
    {
        public long? OptId { get; set; }
        public string OptionText { get; set; }
        public bool IsCorrect { get; set; }
    }
}
