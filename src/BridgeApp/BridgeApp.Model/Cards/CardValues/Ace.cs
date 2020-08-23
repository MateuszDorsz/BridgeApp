namespace BridgeApp.Model.Cards.CardValues
{
    public class Ace : ICardValue
    {
        public Ace()
        {
            Name = "Ace";
            Value = 14;
            Points = 4;
            Symbol = "A";
        }
        public string Name { get; }
        public int Value { get; }
        public int Points { get; }
        public string Symbol { get; }
    }
}
