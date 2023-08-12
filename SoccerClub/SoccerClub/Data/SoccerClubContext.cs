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
            : base(options){}

        public DbSet<User> User { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Match> Matches { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<ContactUs> contactUs { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Category> Category { get; set; }
    }
}
