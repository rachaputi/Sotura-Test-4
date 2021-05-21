using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherAPI.Models
{
    public class ClimateContext :DbContext
    {
        public ClimateContext(DbContextOptions options):base (options)
        {

        }
        public DbSet<Climate> climates { get; set; }
    }
}
