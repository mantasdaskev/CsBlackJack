namespace BlackJack.GAME.CardModels
{
    public class Card
    {
        public Type Type { get; private set; }
        public Face Face { get; private set; }
        public int Value { get; set; }

        public Card (Type type, Face face, int value)
        {
            Type = type;
            Face = face;
            Value = value;
        }

        public Card() { }
    }
}
