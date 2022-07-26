using HawksNestGolf.NET.Shared.Enums;

namespace HawksNestGolf.NET.Shared.Models
{
    public class QueryOptions
    {
        public bool IncludeRelated { get; set; }
        public SortOption[]? OrderBy { get; set; }
        public int Take { get; set; }
        public int Skip { get; set; }

        public static SortOption[] SortOptionsFromQueryString(string? queryString)
        {
            IList<SortOption> sortOptions = new List<SortOption>();
            if (queryString is null)
                return sortOptions.ToArray();

            // parse "name1,desc;name2"
            var options = queryString.Split(';');
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
}
