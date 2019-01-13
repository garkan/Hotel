using System;
using Hotel.data;
using Hotel.eating;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hotel
{
    public partial class FoodWarehouse : Form
    {
        public FoodWarehouse(Manager manager)
        {
            InitializeComponent();
            currentManager = manager;
          
        }
        Eater eat = Eater.Instance;
        ProductExpert products = ProductExpert.Instance;
        Manager currentManager;
        bool flag;

        private void FoodWarehouse_Load(object sender, EventArgs e)
        {
            for (int j = 0; j < eat.records.Count; j++)
            {
                string id = eat.records[j].id_product;
                for (int i = 0; i < products.records.Count; i++)
                {
                    if (products.records[i].id == id)
                    {
                        eat.records[j].id_product = products.records[i].nameProduct;

                        break;

                    }
                }
            }

            foreach (var i in eat.records)
            {
                ListViewItem item1 = new ListViewItem();  
                item1.SubItems.Add(i.id_product.ToString());
                item1.SubItems.Add(i.count.ToString());
                item1.SubItems.Add(i.criticalVolume.ToString());
                listView1.Items.Add(item1);

            }

            for (int i = 0; i < listView1.Items.Count; i++)
            {
                if (Convert.ToInt32(listView1.Items[i].SubItems[2].Text) < Convert.ToInt32(listView1.Items[i].SubItems[3].Text))
                {
                    flag = false;
                    listView1.Items[i].BackColor = Color.Red;
                }   
            }

            if (!flag)
                MessageBox.Show("Необходимо пополнить запасы продуктов на складе!","Уведомление!");

        }

        private void button1_Click(object sender, EventArgs e)
        {
            RecFood rec = new RecFood(new data.Manager(1, "dariast123test@gmail.com", "1q2w3e4r5t"));
            rec.ShowDialog();
            this.Close();
        }
    }
}

