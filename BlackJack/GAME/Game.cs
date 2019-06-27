using System.Collections.Generic;

namespace BlackJack.GAME
{
    public class Game
    {
        private Deck _deck;

        public Game()
        {
            _deck = new Deck();
        }

        public List<Card> HandPlayer { get; private set; }
        public List<Card> HandDealer { get; private set; }
        public int BetAmount { get; private set; }

        public void DealPlayerHand(int betAmount, int usableChips)
        {
            HandPlayer = new List<Card>();
            HandPlayer.Add(_deck.Draw());
            HandPlayer.Add(_deck.Draw());
            HandPlayer.ForEach(c => c.Value = c.Face == Face.ACE ? c.Value + 10 : c.Value);
            BetAmount = betAmount > usableChips ? usableChips : betAmount; 
        }

        public void DealDealerHand()
        {
            HandDealer = new List<Card>();
            HandDealer.Add(_deck.Draw());
            HandDealer.Add(_deck.Draw());
            HandDealer.ForEach(c => c.Value = c.Face == Face.ACE ? c.Value + 10 : c.Value);
        }

        public void DrawPlayerHand()
        {
            HandPlayer.Add(_deck.Draw());
        }

        public void DrawDealerHand()
        {
            HandDealer.Add(_deck.Draw());
        }

        public int HandPoints(List<Card> hand)
        {
            int points = 0;
            foreach (var card in hand)
            {
                points += card.Value;
            }
            
            return points;
        }
    }
}
