using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Locker.DatabaseContext.Model
{
    public class MessageDetail
    {
        [Key]
        public int Id_message { get; set; }
        public DateTime Date { get; set; }
        public DateTime Time { get; set; }
        public bool IsShow { get; set; }

        [ForeignKey("Content")]
        public int Id_contentRef { get; set; }
        [ForeignKey("Account")]
        public string Id_studentRef { get; set; }

    }
}
