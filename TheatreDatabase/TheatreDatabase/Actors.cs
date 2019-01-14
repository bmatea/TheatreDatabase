using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace TheatreDatabase
{
    public class Actors
    {
        public int ActorsId { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }

        public virtual ICollection<Plays> Plays { get; set; }
    }
}
