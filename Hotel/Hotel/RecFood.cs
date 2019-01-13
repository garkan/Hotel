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
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;

namespace Hotel
{
    public partial class RecFood : Form
    {
        public RecFood(Manager manager)
        {
            InitializeComponent();
            currentManager = manager;
            listView1.View = View.Details;
            listView1.CheckBoxes = true;
        }
        Eater eat = Eater.Instance;
        ProductExpert products = ProductExpert.Instance;
        Manager currentManager;
        bool flag;
        private const string path = "../../listproducts.json";
        private const string pathrecord = "../../recordfood.json";
        public List<Listproducts> listprod = new List<Listproducts>();
        public List<RecordFood> recfood = new List<RecordFood>();

        private void button1_Click(object sender, EventArgs e)
        {
            flag = true;
            for (int i = 0; i < listView1.Items.Count; i++)
            {
                if (listView1.Items[i].Checked && listView1.Items[i].SubItems[5].Text != "")
                {
                    flag = false;
                    var id = 1;
                    var id_products = Convert.ToInt32(products.records[i].id);
                    var count = Convert.ToDouble(listView1.Items[i].SubItems[5].Text);
                    var rec = new Listproducts(id, id_products, count);
                    listprod.Add(rec);
                }
            }
            if (flag)
                MessageBox.Show("Вы не выбрали продукты для заказа, либо не указали его количество!", "Ошибка");
            else
            {
                string sJSONResponse = JsonConvert.SerializeObject(listprod);
                File.WriteAllText(path, sJSONResponse);

                var id = 1;
                DateTime date = DateTime.Now;
                var id_manager = 1;
                var id_listproduct = 1;
                var dateend = dateTimePicker1.Value;
                var rec = new RecordFood(id, date, id_manager, id_listproduct, dateend);
                recfood.Add(rec);
                sJSONResponse = JsonConvert.SerializeObject(recfood);
                File.WriteAllText(pathrecord, sJSONResponse);
                MessageBox.Show("Заявка на заказ продуктов оформлена!", "Готово");
                Application.Exit();
            }
        }




        private void RecFood_Load(object sender, EventArgs e)
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
            int cc = 5;
            foreach (var i in eat.records)
            {

                ListViewItem item1 = new ListViewItem();
                item1.SubItems.Add(i.id.ToString());
                item1.SubItems.Add(i.id_product.ToString());
                item1.SubItems.Add(i.count.ToString());
                item1.SubItems.Add(i.criticalVolume.ToString());
                item1.SubItems.Add(cc.ToString());
                listView1.Items.Add(item1);
                cc += 5;

            }

            for (int i = 0; i < listView1.Items.Count; i++)
            {
                if (Convert.ToInt32(listView1.Items[i].SubItems[3].Text) < Convert.ToInt32(listView1.Items[i].SubItems[4].Text))
                {
                    flag = false;
                    listView1.Items[i].BackColor = Color.Red;
                }
            }
        }
    }
}