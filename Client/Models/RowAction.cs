namespace HawksNestGolf.NET.Client.Models
{
    public class RowAction<T>
    {
        public string Icon { get; set; } = string.Empty;
        public string DisplayLabel { get; set; } = string.Empty;
        public string Tooltip { get; set; } = string.Empty;
        public Action<T>? Action { get; set; }
    }
}
