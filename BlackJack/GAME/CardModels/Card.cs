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

        public override string ToString()
        {
            string type = "";
            switch (Type)
            {
                case Type.CLUB : type = "\U00002663"; break;
                case Type.DIAMOND : type = "\U00002666"; break;
                case Type.HEART : type = "\U00002665"; break;
                case Type.SPADE : type = "\U00002660"; break;
            }

            return $"{type} {Face.ToString()}";
        }
    }
}
