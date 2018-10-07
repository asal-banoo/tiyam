using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace Inteface
{
    public interface ICrud
    {
        IQueryable<Product> GetProducts();
        IHttpActionResult GetProduct(int id);
        IHttpActionResult PutProduct(int id, Product product);
        IHttpActionResult PostProduct(Product product);
        IHttpActionResult DeleteProduct(int id);
    }
}
