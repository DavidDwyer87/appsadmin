using AppService.Areas.cafeBlue.Models;
using CafeBlue;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AppService.Areas.cafeBlue.Controllers
{
    public class cafeblueapiController : ApiController
    {
        // GET api/<controller>
        public IEnumerable<ProductsTable> Get(string cati)
        {
            return new ProductModel().getProduct(cati);
        }

        // GET api/<controller>/5
        public ProductsTable Get(string cati,string product)
        {
            return new ProductModel().findProduct(cati, product);
        }

        // POST api/<controller>
        public void Post(FeedbackTable feed)
        {

        }

        //// PUT api/<controller>/5
        //public void Put(int id, [FromBody]string value)
        //{

        //}

        //// DELETE api/<controller>/5
        //public void Delete(int id)
        //{

        //}
    }
}