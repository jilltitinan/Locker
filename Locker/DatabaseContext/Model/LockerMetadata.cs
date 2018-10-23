using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Locker.DatabaseContext.Model
{
    public class LockerMetadata
    {
        [Key]
        public string Mac_address { get; set; }
        public string Location { get; set; }
        public string position { get; set; }
        public bool IsActive { get; set; }
    }
}
