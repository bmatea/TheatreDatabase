using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.Migrations;

namespace TheatreDatabase
{
    public class TheatreContext : DbContext
    {
        public TheatreContext(string s) : base(s) {
            Database.SetInitializer<TheatreContext>(new TheatreDbInitialization());
        }

        public DbSet<Accounts> Accounts { get; set; }
        public DbSet<Actions> Actions { get; set; }
        public DbSet<Actors> Actors { get; set; }
        public DbSet<Auditoriums> Auditoriums {get; set;}
        public DbSet<Plays> Plays { get; set; }
        public DbSet<Users> Users { get; set; }
    }
}
