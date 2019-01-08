using Hotel.booking;
using Hotel.data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hotel
{
    public partial class BookingRoom : Form
    {
        public BookingRoom()
        {
            InitializeComponent();
        }

        private void BookingRoom_Load(object sender, EventArgs e)
        {
            //ImageList imgs = new ImageList();
            //imgs.ImageSize = new Size(50, 50);

            ////LOAD IMGS FROM FILE. SPECIFY YOUR PATH FOR IMAGES
            //String[] paths = { };
            //paths = Directory.GetFiles(@"C:\Users\Дарья\Source\Repos\Hotel\Hotel\Hotel\Pictures");

            //foreach (String path in paths)
            //{
            //    imgs.Images.Add(Image.FromFile(path));
            //}
            //listView1.SmallImageList = imgs;
            //listView1.Items.Add("1", 0);
            //listView1.Items.Add("2", 1);
            var u = new User(1, "abramov", "15625", "Абрамов А.К.", "abramov@mail.ru", "89088456362", Role.Client);
            var r = new Room(1, SingleRoom.Instance, 1200, "r2.jpg");
            var b = new Booker();
            b.Booking(u, r, DateTime.Now, DateTime.Now.AddDays(1));
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
