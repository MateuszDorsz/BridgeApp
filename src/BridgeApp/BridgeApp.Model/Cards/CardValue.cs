namespace BridgeApp.Model.Cards
{
    public interface ICardValue
    {
        string Name { get; }

        int Value { get; }

        int Points { get; }

        string Symbol { get; }
    }
}