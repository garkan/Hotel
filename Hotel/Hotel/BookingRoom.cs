﻿using Hotel.booking;
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
        public BookingRoom(Client user, INotifier _notifier)
        {
            InitializeComponent();
            currentUser = user;
            admin = new Admin(Properties.Resources.AdminEmail, "");
            notifier = _notifier;
            
        }
        Client currentUser;
        Admin admin;
        IRoomExpert iroomexp = RoomExpert.Instance;
        Booker booker = Booker.Instance;
        INotifier notifier;

        private void BookingRoom_Load(object sender, EventArgs e)
        {
            
            button2.Enabled = false;
            ShowFilteredRoom();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ShowFilteredRoom();
        }
        public List<Room> GetFreeFilteredRooms(bool _single, bool _double, bool _triple, DateTime start, DateTime end)
        {
            return iroomexp.Rooms.Where(r => (r.type is SingleRoom && _single) ||
            (r.type is DoubleRoom && _double) || (r.type is TripleRoom && _triple))
            .Where(t => (booker.CheckFree(start, end, t))).ToList(); 
        }

        private void ShowFilteredRoom()
        {
            var _single = checkBox1.Checked;
            var _double = checkBox2.Checked;
            var _triple = checkBox3.Checked;
            var start = dateTimePicker1.Value;
            var end = dateTimePicker2.Value;

            listView1.Items.Clear();
            var result = GetFreeFilteredRooms(_single, _double, _triple, start, end);
           

            ImageList imgs = new ImageList();
            imgs.ImageSize = new Size(100, 100);
            var rooms = result.Select(r =>
            {
                var img = Image.FromFile("../../Pictures/" + r.path_to_img);
                imgs.Images.Add(img);
                var num = imgs.Images.Count - 1;
                return Tuple.Create(r, num);
            });
            listView1.SmallImageList = imgs;
            foreach (var i in rooms)
            {
                ListViewItem lvi = new ListViewItem();
                lvi.SubItems.Add(i.Item1.id.ToString());
                lvi.SubItems.Add(i.Item1.type.FullName);
                lvi.SubItems.Add(i.Item1.cost_per_day.ToString());
                var days = end.Subtract(start).TotalDays;
                lvi.SubItems.Add(Math.Round((i.Item1.cost_per_day * days)).ToString());
                lvi.ImageIndex = i.Item2; // this will display YourImageList.Images[2] in the first column
                listView1.Items.Add(lvi);
            }
            button2.Enabled = true;
        }


        private void button2_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                button2.Enabled = false;
                var t = listView1.SelectedIndices[0];
                var t1 = listView1.Items[t];
                var id = int.Parse(t1.SubItems[1].Text);
                var smt = iroomexp.Rooms.Where(r => id == r.id).First();
                var res = booker.Booking(currentUser, smt, dateTimePicker1.Value, dateTimePicker2.Value);
                if (res !=null)
                {
                    try
                    {
                        MessageBox.Show("Заявка на бронирование успешно создана!");
                        notifier.Notify(res, currentUser, admin);
                    }
                    catch
                    {

                    }
                    button1_Click(null, null);
                }
                button2.Enabled = true;

            }
        }
    }
}
