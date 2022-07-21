namespace HawksNestGolf.NET.Client.Models
{
    public class TableDefinition<T>
    {
        public IList<ColumnDefinition<T>> Columns { get; set; } = new List<ColumnDefinition<T>>();
        public IList<T>? Items { get; set; } = null;
        public IList<RowAction<T>>? RowActions { get; set; } = new List<RowAction<T>>();
        public IList<TableAction<T>>? TableActions { get; set; } = new List<TableAction<T>>();
    }
}
