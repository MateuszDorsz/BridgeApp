namespace BridgeApp.Model.Cards.CardValues
{
    public class Ten : ICardValue
    {
        public Ten()
        {
            Name = "Ten";
            Value = 10;
            Points = 0;
            Symbol = "10";
        }
        public string Name { get; }
        public int Value { get; }
        public int Points { get; }
        public string Symbol { get; }
    }
}
