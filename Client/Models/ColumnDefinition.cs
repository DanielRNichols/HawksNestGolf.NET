namespace HawksNestGolf.NET.Client.Models
{
    public class ColumnDefinition<T>
    {
        public string Header { get; set; } = string.Empty;
        public Func<T, object> Value { get; set; } = (_) => "";
    }
}
