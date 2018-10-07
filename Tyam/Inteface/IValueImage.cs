using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inteface
{
    interface IProductImage
    {
        void Update(int ID,Product Product,string Url);
        void Create(Product product, string Url);
        void Delete(int ID);
    }
}
