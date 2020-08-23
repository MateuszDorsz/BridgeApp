namespace BridgeApp.Model.Cards.CardValues
{
    public class Four : ICardValue
    {
        public Four()
        {
            Name = "Four";
            Value = 4;
            Points = 0;
            Symbol = "4";
        }
        public string Name { get; }
        public int Value { get; }
        public int Points { get; }
        public string Symbol { get; }
    }
}
