using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StirTrekScheduler.Models
{
    public class Track
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public int? SponsorId { get; set; }
    }
}