using BlackJack.GAME;

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
