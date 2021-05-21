using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherAPI.Models
{
    public class Climate
    {
        [Key]
        public int Id { get; set; }
        public DateTime Data { get; set; }
        public string city { get; set; }
        public double HighTemp { get; set; }
        public double LowTemp { get; set; }
        public string Forecast { get; set; }
    }
}
