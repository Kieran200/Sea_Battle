using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sea_Battle
{
    class Computer : Player
    {

        public void ComputerAttack(string [,] userfield, out int counthits)
        {
            Random rnd = new Random();
            B: int x = rnd.Next(3, 13);
            int y = rnd.Next(3, 13);
            counthits = 0;    
            if (userfield[x, y] == "х"|| userfield[x, y] == "о")
            {
                goto B;
            }
            if (userfield[x,y] == "1")
            {
                userfield[x, y] = "х";
            }
            else
            {
                userfield[x, y] = "о";
                counthits += 1;            }
        }
    }
}