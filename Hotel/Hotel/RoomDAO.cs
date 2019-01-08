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
    class RoomDAO
    {
        public List<Room> rooms = new List<Room>();
        public static readonly RoomDAO Instance = new RoomDAO();
        private const string path = "../../rooms.json";
        private RoomDAO()
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
        public Room Add(Room room)
        {
            if (rooms.Count > 0)
            {
                var id = rooms.Select(r => r.id).Max() + 1;
                room.id = id;
            }
            else
                room.id = 1;
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
