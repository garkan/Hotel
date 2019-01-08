using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.data
{
    class Record
    {
        public int id_user;
        public int id_room;
        public DateTime datestart;
        public DateTime dateend;
        public double amount;
        public bool agree;

        public Record(int id_user, int id_room, DateTime datestart, DateTime dateend, double amount, bool agree)
        {
            this.id_user = id_user;
            this.id_room = id_room;
            this.datestart = datestart;
            this.dateend = dateend;
            this.amount = amount;
            this.agree = agree;
        }
        public JObject ToJSON()
        {
            var result = new JObject();
            result["id_user"] = id_user;
            result["id_room"] = id_room;
            result["datestart"] = datestart;
            result["dateend"] = dateend;
            result["amount"] = amount;
            result["agree"] = agree;
            return result;
        }
    }
}
