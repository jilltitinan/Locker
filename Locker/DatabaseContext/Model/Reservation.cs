using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Locker.DatabaseContext.Model
{
    public class Reservation
    {
        [Key]
        public int Id_reserve { get; set; }
        public string Code { get; set; }
        public bool IsActive { get; set; }
        public bool Status { get; set; }
        public DateTime StartDay { get; set; }
        public DateTime EndDay { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        [ForeignKey("Account")]
        public string Id_studentRef { get; set; }
        [ForeignKey("Vacancy")]
        public string Id_vacancyRef { get; set; }
    }
}
