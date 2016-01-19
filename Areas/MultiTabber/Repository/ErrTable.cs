using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AppService.Areas.MultiTabber.Repository
{
    [Table("MultiTabber_Err")]
    public class ErrTable
    {
        [Key]
        public int Index { get; set; }
        public string err { get; set; }
        public string description { get; set; }
        public string date { get; set; }
    }
}