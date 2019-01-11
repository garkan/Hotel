using System;
using Hotel.data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace Hotel.eating
{
    class Eater
    {
        private const string path = "../../oredefood.json";
        public List<OrderFood> records = new List<OrderFood>();
        private Eater()
        {
            if (File.Exists(path))
            {
                var res = JsonConvert.DeserializeObject(File.ReadAllText(path));
                if (res != null)
                {
                    var R = res as JArray;
                    foreach (var r in R)
                    {
                        var rec = r.ToObject<OrderFood>();
                        records.Add(rec);
                    }
                }
            }
        }
    }
}
