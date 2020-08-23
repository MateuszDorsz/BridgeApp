namespace BridgeApp.Model.Cards.CardValues
{
    public class Nine : ICardValue
    {
        public Nine()
        {
            Name = "Nine";
            Value = 9;
            Points = 0;
            Symbol = "9";
        }
        public string Name { get; }
        public int Value { get; }
        public int Points { get; }
        public string Symbol { get; }
    }
}
