using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.data
{
    class Servises
    {
        public int id;
        public RoomType type;
        public string nameService;
        public double cost;

        public Servises(int id, RoomType type, string nameService, double cost)
        {
            this.id = id;
            this.type = type ?? throw new ArgumentNullException(nameof(type));
            this.nameService = nameService;
            this.cost = cost;       
        }
    }
}
