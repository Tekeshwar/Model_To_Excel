using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelToExcel.Model
{
    public class TestModel
    {
        public int ID { get; set; }
        public string Name { get; set; }

       public static List<TestModel> GetData()
        {
            List<TestModel> obj = new List<TestModel>();
            obj.Add(new TestModel() { ID = 1, Name = "c" });
            obj.Add(new TestModel() { ID = 2, Name = "d" });
            return obj;
        }
    }
}
