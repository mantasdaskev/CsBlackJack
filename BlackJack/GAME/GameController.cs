using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BlackJack.GAME
{
    class GameController
    {
        private Game _game;
        private Player _player;

        public GameController()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
        }

        public void Play()
        {
            _player = new Player();

            Console.WriteLine("---**** Back Jack ****---");

            Console.Write("Enter yout name: ");
            _player.Name = Console.ReadLine();
            _player.Chips = ParseChips("Enter starting chips: ");

            _game = new Game();

            while (_player.Chips > 0)
            {
                Deal();
            }
            Console.Clear();
            PrintEnd("GAME OVER", false);
        }

        private void Deal()
        {
            RenderGame(false);
            Console.WriteLine("Dealing hands...");
         
            _game.DealPlayerHand(ParseChips("Enter bet amount: "), _player.Chips);
            _game.DealDealerHand();

            do
            {
                char moove = MakeAMoove();

                if(_game.HandPoints(_game.HandPlayer) == 21)
                {
                    if (_game.HandPoints(_game.HandDealer) == 21)
                    {
                        PrintEnd("It is a TIE!");
                    }
                    else
                    {
                        PlayerWon();
                    }
                    return;
                } else if (_game.HandPoints(_game.HandDealer) == 21)
                {
                    PlayerLost();
                    return;
                }

                if (moove == 's')
                {
                    if(_game.HandPoints(_game.HandDealer) < _game.HandPoints(_game.HandPlayer))
                    {
                        PlayerWon();
                    }
                    else
                    {
                        PlayerLost();
                    }
                    return;
                } else if (moove == 'h') {
                    if (_game.HandPoints(_game.HandPlayer) > 21)
                    {
                        PlayerLost();
                        return;
                    }
                }
            } while (true);
        }

        private char MakeAMoove()
        {
            do
            {
                RenderGame();
                Console.WriteLine("Choose a moove (h - hit)");
                string input = Console.ReadLine();
                if (input.ToLower().Trim() == "h")
                {
                    _game.DrawPlayerHand();
                    return 'h';
                }
                else if (input.ToLower().Trim() == "s")
                {
                    return 's';
                }
                Console.WriteLine("Invalid input!!!"); Thread.Sleep(2000);
            } while (true);
        }

        private int ParseChips(string msg)
        {
            do
            {
                Console.Write(msg);
                if (Int32.TryParse(Console.ReadLine(), out int result))
                {
                   return result;
                }
                Console.WriteLine("Please enter valid amount.");
            } while (true);
        }

        private void RenderGame(bool showHands = true, bool showDealerHand = false)
        {
            Console.Clear();
            Console.WriteLine(_player.ToString());
            Console.WriteLine();

            if (showHands)
            {                
                Console.WriteLine("Dealer's hand:");
                if (showDealerHand)
                {
                    Console.WriteLine(_game.HandDealer[0].ToString());
                }
                else Console.WriteLine("\U0001F0CF");
                Console.WriteLine(_game.HandDealer[1].ToString());
                Console.WriteLine();

                Console.WriteLine("Player's hand:");
                _game.HandPlayer.ForEach(Console.WriteLine);
                Console.WriteLine("Points: " + _game.HandPoints(_game.HandPlayer));
                Console.WriteLine();
            }
        }

        private void PrintEnd(string msg, bool renderGame = true)
        {
            if (renderGame) RenderGame(true, true);
            Console.WriteLine();
            Console.WriteLine(msg);
            Console.WriteLine(_player.ToString());
            Console.WriteLine();
            Console.WriteLine("Press any key to continue...");
            Console.Read();
        }

        private void PlayerWon()
        {
            _player.RecalcChips(_game.BetAmount);
            PrintEnd("You have WON this hand!");
        }
        
        private void PlayerLost()
        {
            _player.RecalcChips(-_game.BetAmount);
            PrintEnd("You have LOST this hand.");
        }
    }
}
