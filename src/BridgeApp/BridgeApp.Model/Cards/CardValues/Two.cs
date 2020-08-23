namespace BridgeApp.Model.Cards.CardValues
{
    public class Two : ICardValue
    {
        public Two()
        {
            Name = "Two";
            Value = 2;
            Points = 0;
            Symbol = "2";
        }
        public string Name { get; }
        public int Value { get; }
        public int Points { get; }
        public string Symbol { get; }
    }
}
