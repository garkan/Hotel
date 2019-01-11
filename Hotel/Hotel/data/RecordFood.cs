using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.data
{
    class RecordFood
    {
        public int id;
        public DateTime date;
        public int id_user;
        public int id_listproduct;
        public DateTime dateend;


        public RecordFood(int id, DateTime date, int id_user, int id_listproduct, DateTime dateend)
        {
            this.id = id;
            this.date = date;
            this.id_user = id_user;
            this.id_listproduct = id_listproduct;
            this.dateend = dateend;
        }
    }
}
