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
        private int _chips;
        private Deck _deck;
        private List<Card> _handDealer;
        private List<Card> _handPlayer;
        private int _betAmunt;

        public Game(int chips)
        {
            _chips = chips;
            _deck = new Deck();
        }

        public List<Card> HandPlayer { get { return _handPlayer; } }
        public List<Card> HandDealer { get { return _handDealer; } }

        public void DealPlayerHand(int betAmount)
        {
            _handPlayer = new List<Card>();
            _handPlayer.Add(_deck.Draw());
            _handPlayer.Add(_deck.Draw());
            _handPlayer.ForEach(c => c.Value = c.Face == Face.ACE ? c.Value + 10 : c.Value);
            _betAmunt = betAmount;

        }

        public void DealDealerHand()
        {
            _handDealer = new List<Card>();
            _handDealer.Add(_deck.Draw());
            _handDealer.Add(_deck.Draw());
            _handDealer.ForEach(c => c.Value = c.Face == Face.ACE ? c.Value + 10 : c.Value);
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
