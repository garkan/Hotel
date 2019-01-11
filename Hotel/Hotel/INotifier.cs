using Hotel.data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel
{
    public interface INotifier
    {
        void Notify(Record r, Client u, Admin a);
    }
}
