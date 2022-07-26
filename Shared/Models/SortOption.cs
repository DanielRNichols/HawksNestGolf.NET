using HawksNestGolf.NET.Shared.Enums;

namespace HawksNestGolf.NET.Shared.Models
{
    public class SortOption
    {
        private string _name = string.Empty;
        public string Name
        {
            get => _name;
            set
            {
                _name = value.ToLower();
            }
        }

        public SortDirection Direction { get; set; } = SortDirection.Ascending;

    }
}
