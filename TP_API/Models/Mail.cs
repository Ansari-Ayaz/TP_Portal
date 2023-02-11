using System;

namespace TP_API.Models
{
    public class Mail
    {
        public string TestName { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string ToName { get; set; }
        public string ToMail { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
    }
}
