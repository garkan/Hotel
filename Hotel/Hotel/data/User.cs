using Hotel.utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.data
{
    public class User
    {
        public int id;
        public string login;
        public string password;
        public string fio;
        public string email;
        public string contact;
        public Role role;

        public User(int id, string login, string password, string fio, string email, string contact, Role role)
        {
            this.id = id;
            this.login = login ?? throw new ArgumentNullException(nameof(login));
            this.password = password ?? throw new ArgumentNullException(nameof(password));
            this.fio = fio ?? throw new ArgumentNullException(nameof(fio));
            this.email = email ?? throw new ArgumentNullException(nameof(email));
            this.contact = contact ?? throw new ArgumentNullException(nameof(contact));
            this.role = role;
            this.password = Hasher.CalculateMD5Hash(this.password);
        }

    }
}
