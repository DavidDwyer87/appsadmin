using AppService.Areas.cafeBlue.Models;
using CafeBlue;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AppService
{
    public class CafeBlueController : ApiController
    {
        public IEnumerable<ProductsTable> Get(int id)
        {
            string cati = "";
            switch (id)
            {
                case 1:
                    {
                        cati = "meal";
                        break;
                    }
                case 2:
                    {
                        cati = "hot";
                        break;
                    }
                case 3:
                    {
                        cati = "cold";
                        break;
                    }
                default:
                    {
                        cati = "meal";
                        break;
                    }
            }

            return new ProductModel().getProduct(cati);
        }

        // GET api/<controller>/5
        public ProductsTable Get(string cati, string product)
        {
            return new ProductModel().findProduct(cati, product);
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}