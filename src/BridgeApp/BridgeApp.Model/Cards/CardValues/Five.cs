namespace BridgeApp.Model.Cards.CardValues
{
    public class Five : ICardValue
    {
        public Five()
        {
            Name = "Five";
            Value = 5;
            Points = 0;
            Symbol = "5";
        }
        public string Name { get; }
        public int Value { get; }
        public int Points { get; }
        public string Symbol { get; }
    }
}
