using System;
using Hotel.data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.IO;

namespace Hotel.eat
{
    class Eatjs
    {
        private const string path = "../../requesteat.json";
        public List<Eat> eat = new List<Eat>();
        private Eatjs()
        {
            if (File.Exists(path))
            {
                var res = JsonConvert.DeserializeObject(File.ReadAllText(path));
                if (res != null)
                {
                    var R = res as JArray;
                    foreach (var r in R)
                    {
                        var rec = r.ToObject<Eat>();
                        eat.Add(rec);
                    }
                }
            }
        }
        public static readonly Eatjs Instance = new Eatjs();
        public Eat Booking(User user, DateTime start, DateTime end)
        {
            //var lst = eat.Where(eat =>
            //{
            //    return eat.id == room.id && ((start > eat.date && start < eat.dateend) ||
            //    (end > eat.date && end < eat.dateend));
            //});
            //if (lst.Count() != 0)
            //    return null;
            //else
            //{
            //    double amount = room.cost_per_day * (end.Subtract(start).TotalDays);
               var eats = new Eat(user.id, start, end);
            //    eat.Add(eats);
            //    Update();
                return eats;
            //}
        }
        public void Update()
        {
            if (!File.Exists(path))
            {
                File.Create(path).Close();
            }
            var arr = new JArray();
            foreach (var r in eat)
            {
                var obj = JObject.FromObject(r);
                arr.Add(obj);
            }
            var s = arr.ToString();
            File.WriteAllText(path, s);
        }
        public bool CheckFree(DateTime start, DateTime end, User user)
        {
            //var lst = eat.Where(record =>
            //{
            //    return record.id_room == room.id && ((start >= record.datestart && start <= record.dateend) ||
            //    (end >= record.datestart && end <= record.dateend));
            //});
            // return (lst.Count() == 0);
            return false;
        }
    }
}
