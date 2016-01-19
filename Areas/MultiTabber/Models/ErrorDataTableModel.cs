using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppService.Areas.MultiTabber.Models
{
    public class ErrorDataTableModel
    {
        public string TableName { get; set; }
        public string DateRange { get; set; }
        public List<EData> errData { get;set; }

    }

    public class EData
    {
        public int Id { get; set; }
        public string err { get; set; }
        public string descrip { get; set; }
        public string date { get; set; }
    }
}