namespace BridgeApp.Model.Cards.CardValues
{
    public class Seven : ICardValue
    {
        public Seven()
        {
            Name = "Seven";
            Value = 7;
            Points = 0;
            Symbol = "7";
        }
        public string Name { get; }
        public int Value { get; }
        public int Points { get; }
        public string Symbol { get; }
    }
}
