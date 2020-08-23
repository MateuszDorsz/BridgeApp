using System.Diagnostics;

namespace BridgeApp.Model.Cards
{
    [DebuggerDisplay("{Color.ToString()} - {CardValue.ToString()}")]
    public class Card
    {
        public Card(Color color, ICardValue cardValue)
        {
            Color = color;
            CardValue = cardValue;
        }

        public Color Color { get; }

        public ICardValue CardValue { get; }
    }
}
