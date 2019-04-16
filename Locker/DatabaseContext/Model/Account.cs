using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Locker.DatabaseContext.Model
{
    public class Account
    {
        [Key]
        public string Id_student { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        public int Point { get; set; }
        //public int FineCount { get; set; }
        //public int PayFineCount { get; set; }
    }
}
