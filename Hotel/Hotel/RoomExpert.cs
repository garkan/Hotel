using Hotel.data;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel
{
    interface IRoomExpert
    {
        Room Add(RoomType type, double cost_per_day, string path_to_img);
        List<Room> Rooms { get; }
        void Update();
    }
    class RoomExpert: IRoomExpert
    {
        public List<Room> rooms = new List<Room>();
        public static readonly RoomExpert Instance = new RoomExpert();
        private const string path = "../../rooms.json";
        private RoomExpert()
        {
            if (File.Exists(path))
            {
                var res = JsonConvert.DeserializeObject(File.ReadAllText(path));
                if (res != null)
                {
                    var R = res as JArray;
                    foreach (var r in R)
                    {
                        var id = r["id"].ToObject<int>();
                        var type = r["type"];
                        var cost_per_day = r["cost_per_day"].ToObject<double>();
                        var path_img = r["path_to_img"].ToObject<string>();
                        RoomType t = null;
                        switch(type["ShortName"].ToObject<string>())
                        {
                            case "SGL":
                                t = SingleRoom.Instance;
                                break;
                            case "DBL":
                                t = DoubleRoom.Instance;
                                break;
                            default:
                                t = TripleRoom.Instance;
                                break;
                        }
                        var rec = new Room(id, t, cost_per_day, path_img);
                        rooms.Add(rec);
                    }
                }
            }
        }
        public List<Room> Rooms => rooms;
        public Room Add(RoomType type, double cost_per_day, string path_to_img)
        {
            int id = 1;
            if (rooms.Count > 0)
            {
                id = rooms.Select(r => r.id).Max() + 1;
                
            }
            var room = new Room(id, type,cost_per_day,path_to_img);
            rooms.Add(room);
            Update();
            return room;
        }
        public void Update()
        {
            if (!File.Exists(path))
            {
                File.Create(path).Close();
            }
            var arr = new JArray();
            foreach (var r in rooms)
            {
                var obj = JObject.FromObject(r);
                arr.Add(obj);
            }
            var s = arr.ToString();
            File.WriteAllText(path, s);
        }
    }
}
