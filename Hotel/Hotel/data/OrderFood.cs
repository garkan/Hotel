using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.data
{
    class OrderFood
    {
        public int id;
        public int id_product;
        public double count;
        public double criticalVolume;

        public OrderFood(int id, int id_product, double count, double criticalVolume)
        {
            this.id = id;
            this.id_product = id_product;
            this.count = count;
            this.criticalVolume = criticalVolume;
        }
    }
}
