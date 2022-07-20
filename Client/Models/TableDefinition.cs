namespace HawksNestGolf.NET.Client.Models
{
    public class TableDefinition<T>
    {
        public IList<ColumnDefinition<T>> Columns { get; set; } = new List<ColumnDefinition<T>>();
        public IList<T>? Items { get; set; } = null;

        public IList<RowAction<T>>? RowActions { get; set; } = new List<RowAction<T>>();

        public TableDefinition(IList<ColumnDefinition<T>> columns, IList<T>? items, IList<RowAction<T>>? rowActions = null)
        {
            Columns = columns;
            Items = items;
            RowActions = rowActions;
        }
    }
}
