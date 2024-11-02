using System.Collections.Generic;

namespace Models.DTO
{
    public class ProcessingTime
    {
        public int PTId { get; set; }
        public string RequestId { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public string ProcessName { get; set; }
        public string Remarks { get; set; }
    }
}
