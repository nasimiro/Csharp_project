using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Food_Ordering_System_WPF
{
    public class MenuItem
    {
        public int id;
        public String name;
        public string price;
        public int Id
        {
            get {return id; } set { this.id = value; }
        }
        public String Name
        {
            get { return name; }
            set { this.name = value; }
        }
        public string Price
        {
            get { return price; }
            set { this.price = value; }
        }
    }
}
