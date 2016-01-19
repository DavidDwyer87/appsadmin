using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AppService.Models
{
    public class ProjectListModel
    {
        public List<SelectListItem> projects { get; set; }
    }
}