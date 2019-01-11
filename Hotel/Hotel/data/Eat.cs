using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.data
{
    class Eat
    {
        public int id_user;
        public DateTime date;
        public DateTime dateend;

        public Eat(int id_user, DateTime date, DateTime dateend)
        {
            this.id_user = id_user;
            this.date = date;
            this.dateend = dateend;
        }
       
    }
}
