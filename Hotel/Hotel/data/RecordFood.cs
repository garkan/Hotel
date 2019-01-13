using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.data
{
    public class RecordFood
    {
        public int id;
        public DateTime date;
        public int id_manager;
        public int id_listproduct;
        public DateTime dateend;


        public RecordFood(int id, DateTime date, int id_manager, int id_listproduct, DateTime dateend)
        {
            this.id = id;
            this.date = date;
            this.id_manager = id_manager;
            this.id_listproduct = id_listproduct;
            this.dateend = dateend;
        }
    }
}
