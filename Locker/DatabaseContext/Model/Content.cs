using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Locker.DatabaseContext.Model
{
    public class Content
    {
        [Key]
        public int Id_content { get; set; }
        public string PlainText { get; set; }
        public bool IsActive { get; set; }
    }
}
