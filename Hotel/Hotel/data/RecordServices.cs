using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.data
{
    class RecordServices
    {
        public int id;
        public int id_servise;
        public DateTime date;
        public int id_user;
        public double cost;


        public RecordServices(int id, int id_servise, DateTime date, int id_user, double cost)
        {
            this.id = id;
            this.id_servise = id_servise;
            this.date = date;
            this.id_user = id_user;
            this.cost = cost;
        }
    }
}
