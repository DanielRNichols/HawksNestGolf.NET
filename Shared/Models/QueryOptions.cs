namespace HawksNestGolf.NET.Shared.Models
{
    public enum SortDirection
    {
        Ascending,
        Descending
    }

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

        public static SortOption[] FromQueryStringParameter(string? queryStringParam)
        {
            IList<SortOption> sortOptions = new List<SortOption>();
            if (queryStringParam is null)
                return sortOptions.ToArray();

            // parse "name1,desc;name2"
            var options = queryStringParam.Split(';');
            foreach (var option in options)
            {
                var sortOption = ParseSortOptionsString(option);
                if (sortOption is not null)
                    sortOptions.Add(sortOption);
            }

            return sortOptions.ToArray();
        }

        private static SortOption? ParseSortOptionsString(string optionStr)
        {
            var parts = optionStr.Split(',');
            if (parts.Length == 0)
                return null;

            var name = parts[0];
            var dir = parts.Length > 1 ? parts[1].ToLower() : "";
            return new SortOption
            {
                Name = name,
                Direction = dir == "desc" ? SortDirection.Descending : SortDirection.Ascending
            };
        }
    }

    public class QueryOptions
    {
        public bool IncludeRelated { get; set; }
        public SortOption[]? OrderBy { get; set; }
        public int Take { get; set; }
        public int Skip { get; set; }
    }
}
