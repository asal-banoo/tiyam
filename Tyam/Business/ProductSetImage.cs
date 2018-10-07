using Inteface;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;


namespace Tyam.Business
{
    public class ProductSetImage : IProductImage
    {
        public ProductSetImage()
        {
        }

        void IProductImage.Create(Product product, string Url)
        {
            string server = null;
            using (DataContext db = new DataContext())
            {
                db.Products.Add(product);
                db.SaveChanges();
                server = db.Servers.Where(s => s.Title == "img").FirstOrDefault().Path;
                db.Image.Add(new Image()
                {
                    Alt = product.Text,
                    FileName = server + Url,
                    Title = product.Title,
                    ProductID = product.ID,
                    ServerID = 1
                });
                db.SaveChanges();
            }


        }

        void IProductImage.Delete(int ID)
        {
            using (DataContext db = new DataContext())
            {
                db.Image.RemoveRange(db.Image.Where(m=>m.ProductID == ID));
                db.Products.Remove(db.Products.Find(ID));
                db.SaveChanges();
            }
        }

        void IProductImage.Update(int ID, Product Product, string Url)
        {
            throw new NotImplementedException();
        }
    }
}