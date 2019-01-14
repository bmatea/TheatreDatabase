using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace TheatreDatabase
{
    public class Auditoriums
    {
        public int AuditoriumsId { get; set; }
        public string name { get; set; }
        public byte NumberOfSeats { get; set; }
        public byte NumberOfAvailableSeats { get; set; }

    }
}
