using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SoccerClub.Models;

namespace SoccerClub.Data
{
    public class SoccerClubContext : DbContext
    {
        public SoccerClubContext (DbContextOptions<SoccerClubContext> options)
            : base(options)
        {
        }

        public DbSet<SoccerClub.Models.User> User { get; set; } = default!;
    }
}
