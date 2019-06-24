using System;
using System.Collections.Generic;

using BlackJack.GAME.CardModels;

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
                    _cards.Add(new Card((CardModels.Type)i, (Face)j, j <= 8 ? j + 1 : 10));
                }
            }
            Shuffle();
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

        private void Shuffle()
        {
            Random random = new Random();
            int randomIndex = 0;

            for (int i = 0; i < _cards.Count - 1; i++)
            {
                randomIndex = random.Next(i + 1);
                Card card = _cards[randomIndex];
                _cards[randomIndex] = _cards[i];
                _cards[i] = card;
            }
        }
    }
}
