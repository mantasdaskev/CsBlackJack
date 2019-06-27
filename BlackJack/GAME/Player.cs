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

        internal void AddChips(int betAmount)
        {
            Chips = Chips + betAmount;
        }
    }
}
