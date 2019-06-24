using BlackJack.GAME.CardModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.GAME
{
    public class Game
    {
        private Deck _deck;
        private List<Card> _handDealer;
        private List<Card> _handPlayer;

        public Game()
        {
            _deck = new Deck();
        }

        public List<Card> HandPlayer { get { return _handPlayer; } }
        public List<Card> HandDealer { get { return _handDealer; } }
        public int BetAmount { get; private set; } = 0; //TODO: gal ir nereikes inicijuot, DELETE jei nereikes

        public void DealPlayerHand(int betAmount, int usableChips)
        {
            _handPlayer = new List<Card>();
            _handPlayer.Add(_deck.Draw());
            _handPlayer.Add(_deck.Draw());
            _handPlayer.ForEach(c => c.Value = c.Face == Face.ACE ? c.Value + 10 : c.Value);
            BetAmount = betAmount > usableChips ? usableChips : betAmount; 
        }

        public void DealDealerHand()
        {
            _handDealer = new List<Card>();
            _handDealer.Add(_deck.Draw());
            _handDealer.Add(_deck.Draw());
            _handDealer.ForEach(c => c.Value = c.Face == Face.ACE ? c.Value + 10 : c.Value);
        }

        public void DrawPlayerHand()
        {
            _handPlayer.Add(_deck.Draw());
        }

        public void DrawDealerHand()
        {
            _handDealer.Add(_deck.Draw());
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
