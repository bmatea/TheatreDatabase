using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TheatreDatabase
{
    public class Accounts
    {
        public int AccountsId { get; set; }
        public decimal Balance { get; set; }
        public virtual ICollection<Actions> Actions { get; set; }
    }
}
