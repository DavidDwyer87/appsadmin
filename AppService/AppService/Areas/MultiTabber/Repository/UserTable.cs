using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AppService.Areas.MultiTabber.Repository
{
    [Table("MultiTabberModels")]
    public class UserTable
    {
        [Key]
        public int Index { get; set; }
        public string email { get; set; }
        public string lastused { get; set; }
        public int ActiveCount { get; set; }
    }
}