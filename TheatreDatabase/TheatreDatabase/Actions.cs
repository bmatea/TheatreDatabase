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
    public abstract class Actions
    {
        public int ActionsId { get; set; }
        public DateTime date { get; set; }

        public abstract decimal PerformAction(decimal x, int acc, int audit);
        
        public int AccountsId { get; set; }
        public int PlaysId { get; set; }
        public virtual Plays Play { get; set; }
        public virtual Accounts Accounts { get; set; }
    }
}
