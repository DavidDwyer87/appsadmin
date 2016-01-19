using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppService.Areas.cafeBlue.Models
{
    public class NewProductModel
    {
        public string ProductName { get; set; }
        public string ProductCatigory { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public string medprice { get; set; }
        public string largeprice { get; set; }
    }
}