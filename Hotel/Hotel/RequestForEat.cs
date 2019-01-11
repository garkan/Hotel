using System;
using Hotel.eat;
using Hotel.data;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hotel
{
    public partial class RequestForEat : Form
    {
        public RequestForEat(User user)
        {
            InitializeComponent();
            currentUser = user;
        }
        User currentUser;
        IRoomExpert iroomexp = RoomExpert.Instance;
        Eatjs eat = Eatjs.Instance;

        private void RequestForEat_Load(object sender, EventArgs e)
        {

        }

        void LoadForm()
        {
            //var _single = checkBox1.Checked;
            //var _double = checkBox2.Checked;
            //var _triple = checkBox3.Checked;
            //var start = dateTimePicker1.Value;
            //var end = dateTimePicker2.Value;

            //listView1.Items.Clear();
            //var result = iroomexp.Rooms.Where(r => (r.type is SingleRoom && _single) ||
            //(r.type is DoubleRoom && _double) || (r.type is TripleRoom && _triple))
            //.Where(t => (booker.CheckFree(start, end, t)));

            //ImageList imgs = new ImageList();
            //imgs.ImageSize = new Size(100, 100);
            //var rooms = result.Select(r =>
            //{
            //    var img = Image.FromFile("../../Pictures/" + r.path_to_img);
            //    imgs.Images.Add(img);
            //    var num = imgs.Images.Count - 1;
            //    return Tuple.Create(r, num);
            //});
            //listView1.SmallImageList = imgs;
            //foreach (var i in rooms)
            //{
            //    ListViewItem lvi = new ListViewItem();
            //    lvi.SubItems.Add(i.Item1.id.ToString());
            //    lvi.SubItems.Add(i.Item1.type.FullName);
            //    lvi.SubItems.Add(i.Item1.cost_per_day.ToString());
            //    var days = end.Subtract(start).TotalDays;
            //    lvi.SubItems.Add(Math.Round((i.Item1.cost_per_day * days)).ToString());
            //    lvi.ImageIndex = i.Item2; // this will display YourImageList.Images[2] in the first column
            //    listView1.Items.Add(lvi);
            //}
        }
    }
}
