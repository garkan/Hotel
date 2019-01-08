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
        public Record Booking(User user, Room room, DateTime start, DateTime end)
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
                var record = new Record(user.id, room.id, start, end, amount, false);
                records.Add(record);
                Update();
                return record;
            }
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
                (end >= record.datestart && end <= record.dateend));
            });
            return (lst.Count() == 0);
        }
    }
}
