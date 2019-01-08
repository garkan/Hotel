using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.data
{
    public interface RoomType
    {
        string ShortName { get;}
        string FullName { get;}
    }
    class SingleRoom : RoomType
    {
        public string ShortName => "SGL";
        public string FullName => "Single";
        private SingleRoom()
        {
        }
        public readonly SingleRoom Instance = new SingleRoom();
    }
    class DoubleRoom : RoomType
    {
        public string ShortName => "DBL";
        public string FullName => "Double";
        private DoubleRoom()
        {
        }
        public readonly DoubleRoom Instance = new DoubleRoom();
    }
    class TripleRoom : RoomType
    {
        public string ShortName => "TRPL";
        public string FullName => "Triple";
        private TripleRoom()
        {
        }
        public readonly TripleRoom Instance = new TripleRoom();
    }
}
