using AppService.Areas.MultiTabber.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppService.Areas.MultiTabber.Models
{
    public class DataTableModel
    {
        public string TableName { get; set; }
        public string DateRange { get; set; }
        public List<MData> MData { get;set; }
    }

   public class MData
   {
       public int Id{get;set;}
       public string email{get;set;}
       public string lastused{get;set;}
       public int ActivityCount{get;set;}
   }
}