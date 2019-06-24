using BlackJack.GAME;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    class Program
    {
        static void Main(string[] args)
        {
            GameController gameController = new GameController();
            gameController.Play();
        }
    }
}
