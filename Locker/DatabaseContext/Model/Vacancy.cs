﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Locker.DatabaseContext.Model
{
    public class Vacancy
    {
        [Key]
        public int Id_vacancy { get; set; }
        public string No_vacancy { get; set; }
        public string Size { get; set; }
        public bool IsActive { get; set; }

        [ForeignKey("LockerMetadata")]
        public string Mac_addressRef { get; set; }
       
    }
}
