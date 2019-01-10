using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.data
{
    class Manager
    {
        public int id;
        public string email;
        public string password;

        public Manager(int id, string email, string password)
        {
            this.id = id;
            this.email = email ?? throw new ArgumentNullException(nameof(email));
            this.password = password ?? throw new ArgumentNullException(nameof(password));
        }
    }
}
