using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StirTrekScheduler.Models
{
    public class TimeSlotFilter
    {
        public int Id { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public bool IsSelected { get; set; }

        public string Name
        {
            get
            {
                return string.Concat(StartTime.ToShortTimeString(), " - ", EndTime.ToShortTimeString());
            }
        }
    }
}