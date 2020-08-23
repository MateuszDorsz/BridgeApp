namespace BridgeApp.Model.Cards.CardValues
{
    public class Queen : ICardValue
    {
        public Queen()
        {
            Name = "Queen";
            Value = 12;
            Points = 2;
            Symbol = "Q";
        }
        public string Name { get; }
        public int Value { get; }
        public int Points { get; }
        public string Symbol { get; }
    }
}
