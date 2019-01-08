using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.data
{
    public class Room
    {
        public int id;
        public RoomType type;
        public double cost_per_day;
        public string path_to_img;

        public Room(int id, RoomType type, double cost_per_day, string path_to_img)
        {
            this.id = id;
            this.type = type ?? throw new ArgumentNullException(nameof(type));
            this.cost_per_day = cost_per_day;
            this.path_to_img = path_to_img;
        }
    }
}
