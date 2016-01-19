using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AppService.Repository
{
    [Table("project_tbl")]
    public class project_tbl
    {
        [Key]
        public int Id { get; set; }
        public string proj { get; set; }
        public string url { get; set; }        
        public bool PageActive { get; set; }
    }
}