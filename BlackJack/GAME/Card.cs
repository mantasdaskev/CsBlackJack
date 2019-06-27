namespace BlackJack.GAME
{
    public enum Face
    {
        ACE,
        TWO,
        THREE,
        FOUR,
        FIVE,
        SIX,
        SEVEN,
        EIGHT,
        NINE,
        TEN,
        JACK,
        QUEEN,
        KING
    }

    public enum Suit
    {
        CLUB,
        DIAMOND,
        HEART,
        SPADE
    }

    public class Card
    {
        public Suit Type { get; private set; }
        public Face Face { get; private set; }
        public int Value { get; set; }

        public Card (Suit type, Face face, int value)
        {
            Type = type;
            Face = face;
            Value = value;
        }

        public Card() { }

        public override string ToString()
        {
            string type = "";
            switch (Type)
            {
                case Suit.CLUB : type = "\U00002663"; break;
                case Suit.DIAMOND : type = "\U00002666"; break;
                case Suit.HEART : type = "\U00002665"; break;
                case Suit.SPADE : type = "\U00002660"; break;
            }

            return $"{type} {Face.ToString()}";
        }
    }
}
