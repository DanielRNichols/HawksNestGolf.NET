namespace HawksNestGolf.NET.Client.Models
{
    public class TableAction<T>
    {
        public string Icon { get; set; } = string.Empty;
        public string DisplayLabel { get; set; } = string.Empty;
        public string Tooltip { get; set; } = string.Empty;
        public Action<IList<T>>? Action { get; set; }

    }
}
