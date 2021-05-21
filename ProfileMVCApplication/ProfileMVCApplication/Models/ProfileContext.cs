using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProfileMVCApplication.Models
{
    public class ProfileContext : DbContext
    {
        public ProfileContext(DbContextOptions options):base(options)
        {

        }
        public DbSet<Profile> profiles { get; set; }
    }
}
