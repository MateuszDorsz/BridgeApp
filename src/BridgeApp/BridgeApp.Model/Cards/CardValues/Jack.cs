namespace BridgeApp.Model.Cards.CardValues
{
    public class Jack : ICardValue
    {
        public Jack()
        {
            Name = "Jack";
            Value = 11;
            Points = 1;
            Symbol = "J";
        }
        public string Name { get; }
        public int Value { get; }
        public int Points { get; }
        public string Symbol { get; }
    }
}
