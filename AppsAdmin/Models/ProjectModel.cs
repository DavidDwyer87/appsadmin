using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppService.Models
{
    public class ProjectModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Page_Count { get; set; }
        public bool Status { get; set; }
    }
}