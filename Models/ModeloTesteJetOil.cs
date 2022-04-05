using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Root
    {
        public List<Category> categories { get; set; }
    }

    public class Category
    {
        public int id { get; set; }
        public string name { get; set; }
    }
}
