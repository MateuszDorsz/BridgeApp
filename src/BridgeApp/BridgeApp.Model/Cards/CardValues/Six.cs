namespace BridgeApp.Model.Cards.CardValues
{
    public class Six : ICardValue
    {
        public Six()
        {
            Name = "Six";
            Value = 6;
            Points = 0;
            Symbol = "6";
        }
        public string Name { get; }
        public int Value { get; }
        public int Points { get; }
        public string Symbol { get; }
    }
}
