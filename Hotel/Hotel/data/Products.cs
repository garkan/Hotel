using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.data
{
    class Products
    {
        public int id;
        public string nameProduct;
        public string unit;
       

        public Products(int id, string nameProduct, string unit)
        {
            this.id = id;
            this.nameProduct = nameProduct;
            this.unit = unit;
        }
    }
}
