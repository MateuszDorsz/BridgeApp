namespace BridgeApp.Model.Cards.CardValues
{
    public class Eight : ICardValue
    {
        public Eight()
        {
            Name = "Eight";
            Value = 8;
            Points = 0;
            Symbol = "8";
        }
        public string Name { get; }
        public int Value { get; }
        public int Points { get; }
        public string Symbol { get; }
    }
}
