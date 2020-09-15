namespace BridgeApp.Model
{
    public class Table
    {
        public ITableChat TableChat { get; }

        public Table(int id)
        {
            Id = id;
            TableChat = new TableChat();
        }

        public int Id { get; private set; }
    }
}
