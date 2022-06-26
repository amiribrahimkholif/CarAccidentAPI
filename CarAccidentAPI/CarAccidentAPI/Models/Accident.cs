using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarAccidentAPI.Models
{
    public class Accident
    {
        public int Id { get; set; }
        public string City { get; set; }
        public bool IsAccident { get; set; }
        public DateTime Time { get; set; }

    }
}
