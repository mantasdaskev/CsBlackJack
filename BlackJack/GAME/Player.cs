using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.GAME
{
    public class Player
    {
        public string Name { get; set; }
        public int Chips { get; set; }

        public override string ToString()
        {
            return $"Player name: {Name}\n" +
                   $"Player chips: {Chips.ToString()}";
        }

        internal void RecalcChips(int betAmount)
        {
            Chips = Chips + betAmount;
        }
    }
}
