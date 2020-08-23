namespace BridgeApp.Model.Cards.CardValues
{
    public class Three : ICardValue
    {
        public Three()
        {
            Name = "Three";
            Value = 3;
            Points = 0;
            Symbol = "3";
        }

        public string Name { get; }
        public int Value { get; }
        public int Points { get; }
        public string Symbol { get; }
    }
}
