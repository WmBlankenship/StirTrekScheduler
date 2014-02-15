using Newtonsoft.Json;
using StirTrekScheduler.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace StirTrekScheduler.Controllers
{
    public class SponsorsController : Controller
    {
        private List<Sponsor> _sponsors = new List<Sponsor>();
        public ActionResult Index()
        {
            GetSponsors();
            return View(_sponsors);
        }

        private void GetSponsors()
        {
            dynamic json = JsonConvert.DeserializeObject<StirTrekJsonModel>(new WebClient().DownloadString("http://stirtrek.com/Feed/JSON"));

            _sponsors = json.Sponsors;
        }
	}
}