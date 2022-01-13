using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XO
{
    class Program
    {
        static void Main(string[] args)
        {
            Main_Game game=new Main_Game(new Player("Hicham"), new Player("Z"));
            char p;
            do
            {
                game.Start_Game();
                Console.WriteLine("Do want to replay Again? (Y for yes)");
                p = Char.ToUpper(Char.Parse(Console.ReadLine()));
            } while (p == 'Y');
            Console.ReadKey();
        }
    }
}
