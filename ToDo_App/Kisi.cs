using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDo_App
{
    public class Kisi
    {
        public Kisi(int _id,string _name)
        {
            this.Name = _name;
            this.Id = _id;
        }
        public Kisi(string _name)
        {
            this.Name = _name;
            id++;
        }

        int id = 1;
        string name;

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
    }
}
