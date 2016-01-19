using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AppService.Repository
{
    [Table("projectStatus")]
    public class projectStatus
    {
        [Key]
        public int Id { get; set; }
        public string project { get; set; }
        public bool status { get; set; }
    }
}