using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.data
{
    public class Listproducts
    {
        public int id;
        public int id_products;
        public double count;


        public Listproducts(int id,  int id_products, double count)
        {
            this.id = id;
            this.id_products = id_products;
            this.count = count;
    
        }
    }
}
