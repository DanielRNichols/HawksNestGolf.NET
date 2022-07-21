namespace HawksNestGolf.NET.Client.Models
{
    public class AdminPage<T>
    {
        public string Header { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public TableDefinition<T>? TableDefinition { get; set; }

    }
}
