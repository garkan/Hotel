using System;
using System.Collections.Generic;
using Hotel.data;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hotel
{
    public partial class ServicesOrder : Form
    {
        public ServicesOrder(Client user, INotifier _notifier)
        {
            InitializeComponent();
            currentUser = user;
            admin = new Admin(Properties.Resources.AdminEmail, "");
            notifier = _notifier;
        }
        Client currentUser;
        Admin admin;
        IRoomExpert iroomexp = RoomExpert.Instance;
        //Booker booker = Booker.Instance;
        INotifier notifier;

        private void ServicesOrder_Load(object sender, EventArgs e)
        {

        }
    }
}
