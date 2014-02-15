using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StirTrekScheduler.Models
{
    public class StirTrekJsonModel
    {
        public List<Track> Tracks { get; set; }
        public List<TimeSlot> TimeSlots { get; set; }
        public List<Speaker> Speakers { get; set; }
        public List<Session> Sessions { get; set; }
        public List<Sponsor> Sponsors { get; set; }
    }
}