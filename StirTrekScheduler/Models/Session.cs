using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StirTrekScheduler.Models
{
    public class Session
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Abstract { get; set; }
        public List<int> SpeakerIds { get; set; }
        public int TimeSlotId { get; set; }
        public int? TrackId { get; set; }
    }
}