namespace BridgeApp.Model.Cards.CardValues
{
    public class King : ICardValue
    {
        public King()
        {
            Name = "King";
            Value = 13;
            Points = 3;
            Symbol = "K";
        }
        public string Name { get; }
        public int Value { get; }
        public int Points { get; }
        public string Symbol { get; }
    }
}
