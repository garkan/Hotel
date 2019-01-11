using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.data
{
    interface ServicesType
    {
        string FullName { get; }
    }
    class SingleType : ServicesType
    {
        public string FullName => "Такси";
        private SingleType()
        {
        }
        public static readonly SingleType Instance = new SingleType();
    }
    class DoubleType : ServicesType
    {
        public string FullName => "Еда";
        private DoubleType()
        {
        }
        public static readonly DoubleType Instance = new DoubleType();
    }
    class TripleType : ServicesType
    {
        public string FullName => "Уборка";
        private TripleType()
        {
        }
        public static readonly TripleType Instance = new TripleType();
    }
}
