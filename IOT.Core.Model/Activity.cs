using System;

namespace IOT.Core.Model
{
    public class Activity
    {
        public int ActivityId { get; set; }
        public string ActivityName { get; set; }
        public DateTime BeginTime { get; set; }
        public string BeginTimes { get { return BeginTime.ToString("yyyy-MM-dd HH:mm:ss"); } }
        public DateTime EndTime { get; set; }
        public string EndTimes { get { return EndTime.ToString("yyyy-MM-dd HH:mm:ss"); } }
        public string Slideshow { get; set; }
        public int State { get; set; }
        public DateTime CreateDate { get; set; }
        public string CreateDates { get { return CreateDate.ToString("yyyy-MM-dd HH:mm:ss"); } }
        public int ActivityTime { get; set; }
        public string stimes { get; set; }
        public string ztimes { get; set; }
    }
}
