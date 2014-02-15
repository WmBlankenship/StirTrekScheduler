using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StirTrekScheduler.Models
{
    public class SessionViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Abstract { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public List<string> Speakers { get; set; }
        public string Track { get; set; }

        public string DisplayTime
        {
            get
            {
                return string.Format("{0} - {1}", StartTime.ToString("t"), EndTime.ToString("t"));
            }
        }
    }
}