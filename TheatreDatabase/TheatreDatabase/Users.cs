using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace TheatreDatabase
{
    public class Users
    {
        public int UsersId { get; set; }
        public string username { get; set; }
        public int password { get; set; }

        public int AccountsId { get; set; }
        public virtual Accounts Account { get; set; }
    }
}
