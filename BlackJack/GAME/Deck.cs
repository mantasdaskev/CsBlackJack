using BlackJack.GAME.Extentions;
using System.Collections.Generic;

namespace BlackJack.GAME
{
    public class Deck
    {
        private List<Card> _cards;

        public Deck()
        {
            Make();
        }

        public void Make()
        {
            _cards = new List<Card>();

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 13; j++)
                {
                    _cards.Add(new Card((Suit)i, (Face)j, j <= 8 ? j + 1 : 10));
                }
            }
            _cards.Shuffle();
        }

        public Card Draw()
        {
            if (_cards.Count == 0)
            {
                Make();
            }

            Card card = _cards[_cards.Count - 1];
            _cards.RemoveAt(_cards.Count - 1);
            return card;
        }

        public int GetCradsCount()
        {
            return _cards.Count;
        }
    }
}
