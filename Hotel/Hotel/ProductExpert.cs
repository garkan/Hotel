using Hotel.data;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel
{
    class ProductExpert
    {
        private const string path = "../../products.json";
        public List<Products> records = new List<Products>();
        private ProductExpert()
        {
            if (File.Exists(path))
            {
                var res = JsonConvert.DeserializeObject(File.ReadAllText(path));
                if (res != null)
                {
                    var R = res as JArray;
                    foreach (var r in R)
                    {
                        var id = r["id"].ToObject<string>();
                        var nameProduct = r["nameProduct"].ToObject<string>();
                        var unit = r["unit"].ToObject<string>();


                        var rec = new Products(id, nameProduct, unit);
                        records.Add(rec);
                    }
                }
            }
        }
        public static readonly ProductExpert Instance = new ProductExpert();


    }
}
