using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StirTrekScheduler.Models
{
    public class SchedulerViewModel
    {
        public List<SessionViewModel> Sessions { get; set; }
        public List<TimeSlotFilter> TimeSlotFilters { get; set; }
        public List<TimeSlotFilter> SelectedTimeSlotFilters { get; set; }
        public List<PostedTimeSlot> PostedTimeSlots { get; set; }
        public List<TrackFilter> TrackFilters { get; set; }
        public List<TrackFilter> SelectedTrackFilters { get; set; }
        public List<PostedTrack> PostedTracks { get; set; }

    }

    public class PostedTimeSlot
    {
        public string[] TimeSlotIds { get; set; }
    }

    public class PostedTrack
    {
        public string[] TrackId { get; set; }
    }
}