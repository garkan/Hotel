using Hotel.data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace Hotel.booking
{
    class Booker
    {
        private const string path = "../../records.json";
        public List<Record> records = new List<Record>();
        private Booker()
        {
            if (File.Exists(path))
            {
                var res = JsonConvert.DeserializeObject(File.ReadAllText(path));
                if (res != null)
                {
                    var R = res as JArray;
                    foreach (var r in R)
                    {
                        var rec = r.ToObject<Record>();
                        records.Add(rec);
                    }
                }
            }
        }
        public static readonly Booker Instance = new Booker();
        public Record Booking(Client user, Room room, DateTime start, DateTime end)
        {
            var lst = records.Where(record =>
            {
                return record.id_room == room.id && ((start>record.datestart && start < record.dateend) || 
                (end > record.datestart && end < record.dateend));
            });
            if (lst.Count() != 0)
                return null;
            else
            {
                double amount = room.cost_per_day * (end.Subtract(start).TotalDays);
                return CreateRecord(user.id, room.id, start, end, amount, false);
            }
        }
 
        public Record CreateRecord(int id_user, int id_room, DateTime datestart, DateTime dateend, double amount, bool agree)
        {
            int id = 1;
            if (records.Count > 0)
            {
                id = records.Select(r => r.id).Max() + 1;

            }
            var rec = new Record(id, id_user, id_room, datestart, dateend, amount, agree);
            records.Add(rec);
            Update();
            return rec;
        }
        public void Update()
        {
            if (!File.Exists(path))
            {
                File.Create(path).Close();
            }
            var arr = new JArray();
            foreach (var r in records)
            {
                var obj = JObject.FromObject(r);
                arr.Add(obj);
            }
            var s = arr.ToString();
            File.WriteAllText(path, s);
        }
        public bool CheckFree(DateTime start, DateTime end, Room room)
        {
            var lst = records.Where(record =>
            {
                return record.id_room==room.id && ((start >= record.datestart && start <= record.dateend) ||
                (end >= record.datestart && end <= record.dateend)||
                (start <= record.datestart && end >= record.dateend));
            });
            return (lst.Count() == 0);
        }
    }
}
