namespace HawksNestGolf.NET.Client.Models
{
    public class TableDefinition<T>
    {
        public IList<ColumnDefinition<T>> Columns { get; set; } = new List<ColumnDefinition<T>>();
        public IList<T>? Items { get; set; } = null;

        public TableDefinition(IList<ColumnDefinition<T>> columns, IList<T>? items)
        {
            Columns = columns;
            Items = items;
        }
    }
}
