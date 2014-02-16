using Newtonsoft.Json;
using StirTrekScheduler.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace StirTrekScheduler.Controllers
{
    public class HomeController : Controller
    {
        private List<Track> _tracks = new List<Track>();
        private List<Speaker> _speakers = new List<Speaker>();
        private List<Session> _sessions = new List<Session>();
        private List<Sponsor> _sponsors = new List<Sponsor>();
        private List<TimeSlot> _timeSlots = new List<TimeSlot>();
        private List<TrackFilter> _trackFilters = new List<TrackFilter>();
        private List<TimeSlotFilter> _timeSlotFitlers = new List<TimeSlotFilter>();

        [HttpGet]
        public ActionResult Index()
        {
            GetScheduleFeed();
            GetTrackFilters();
            GetTimeSlotFilters();

            return View(GetSchedulerViewModel());
        }

        [HttpPost]
        public ActionResult Index(SchedulerViewModel model)
        {
            //_trackFilters = model.TrackFilters;
            //_timeSlotFitlers = model.TimeSlotFilters;

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Boosh";

            return View();
        }

        private void GetScheduleFeed()
        {
            dynamic json = JsonConvert.DeserializeObject<StirTrekJsonModel>(new WebClient().DownloadString("http://stirtrek.com/Feed/JSON"));

            _sessions = json.Sessions;
            _speakers = json.Speakers;
            _timeSlots = json.TimeSlots;
            _sponsors = json.Sponsors;
            _tracks = json.Tracks; // Is location a needed field?
        }

        private SchedulerViewModel GetSchedulerViewModel()
        {
            return new SchedulerViewModel
            {
                Sessions = GetSessionViewModel().OrderBy(s => s.StartTime).ToList(),
                TrackFilters = _trackFilters,
                TimeSlotFilters = _timeSlotFitlers.OrderBy(t => t.StartTime).ToList()
            };
        }

        private IEnumerable<SessionViewModel> GetSessionViewModel()
        {
            foreach (var session in _sessions)
            {
                var timeSlot = GetTimeSlotForSession(session);

                yield return (new SessionViewModel
                {
                    Id = session.Id,
                    Name = session.Name,
                    Abstract = session.Abstract,
                    StartTime = timeSlot.StartTime,
                    EndTime = timeSlot.EndTime,
                    Speakers = GetSpeakerNameList(session.SpeakerIds).ToList(),
                    TrackName = GetTrackNameForSession(session)
                });
            }
        }

        private TimeSlot GetTimeSlotForSession(Session session)
        {
            return _timeSlots
                .Where(t => t.Id == session.TimeSlotId)
                .FirstOrDefault();
        }

        private string GetTrackNameForSession(Session session)
        {
            return (session.TrackId > 0
                ? _tracks.Where(t => t.Id == session.TrackId).FirstOrDefault().Name
                : string.Empty);
        }

        private IEnumerable<string> GetSpeakerNameList(List<int> speakerIds)
        {
            foreach (int id in speakerIds)
            {
                yield return (from s in _speakers
                              where s.Id == id
                              select s.Name).FirstOrDefault();
            }
        }

        private void GetTimeSlotFilters()
        {
            foreach (var timeSlot in _timeSlots)
            {
                _timeSlotFitlers.Add(new TimeSlotFilter
                {
                    Id = timeSlot.Id,
                    StartTime = timeSlot.StartTime,
                    EndTime = timeSlot.EndTime,
                    IsSelected = false
                });
            }
        }

        private void GetTrackFilters()
        {
            foreach (var track in _tracks)
            {
                _trackFilters.Add(new TrackFilter
                {
                    Id = track.Id,
                    Name = track.Name,
                    IsSelected = false
                });
            }
        }
    }
}