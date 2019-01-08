using Hotel.data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json.Linq;

namespace Hotel.booking
{
    class Booker
    {
        private const string path = "../../database.json";
        public List<Record> records = new List<Record>();
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
                var obj = r.ToJSON();
                arr.Add(obj);
            }
            var s = arr.ToString();
            File.WriteAllText(path, s);
        }
    }
}
