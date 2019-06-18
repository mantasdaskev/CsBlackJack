using System;
using System.Collections.Generic;

using BlackJack.GAME.CardModels;

namespace BlackJack.GAME
{
    public class Deck
    {
        private List<Card> cards;

        public Deck()
        {
            Initialize();
        }

        public void Initialize()
        {
            cards = new List<Card>();

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 13; j++)
                {
                    cards.Add(new Card((CardModels.Type)i, (Face)j, j <= 8 ? j + 1 : 10)); //TODO: reiketu pervadint type
                }
            }
            Shuffle();
        }

        public Card Draw()
        {
            if (cards.Count == 0)
            {
                Initialize();
            }

            Card card = cards[cards.Count - 1];
            cards.RemoveAt(cards.Count - 1);
            return card;
        }

        public int GetAmountOfRemainingCrads()
        {
            return cards.Count;
        }

        public override string ToString()
        {
            //TODO
            string deckData = "";
            return deckData;
        }

        private void Shuffle()
        {
            Random random = new Random();
            int randomIndex = 0;

            for (int i = 0; i < cards.Count - 1; i++)
            {
                randomIndex = random.Next(i + 1);
                Card card = cards[randomIndex];
                cards[randomIndex] = cards[i];
                cards[i] = card;
            }
        }
    }
}
