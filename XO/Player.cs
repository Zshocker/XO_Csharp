using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XO
{
    class Player
    {
        string name;
        public Player(string s)
        {
            name = s;
        }
        public void Print_name()
        {
            Console.Write(name);
        }
    }
}
