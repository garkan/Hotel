using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.data
{
    public class Room
    {
        private int id;
        private RoomType type;
        private double cost_per_day;

        public Room(int id, RoomType type, double cost_per_day)
        {
            this.id = id;
            this.type = type ?? throw new ArgumentNullException(nameof(type));
            this.cost_per_day = cost_per_day;
        }
    }
}
