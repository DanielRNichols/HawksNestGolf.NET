namespace HawksNestGolf.NET.Shared.Models
{
    public enum OrderByDirection
    {
        Ascending,
        Descending
    }

    public class OrderByOption
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

        public OrderByDirection Direction { get; set; } = OrderByDirection.Ascending;

        public static OrderByOption[] FromQueryStringParameter(string? queryStringParam)
        {
            IList<OrderByOption> orderBy = new List<OrderByOption>();
            if (queryStringParam is null)
                return orderBy.ToArray();

            // parse "name1,desc;name2"
            var options = queryStringParam.Split(';');
            foreach (var option in options)
            {
                var orderByOption = ParseOptionString(option);
                if (orderByOption is not null)
                    orderBy.Add(orderByOption);
            }

            return orderBy.ToArray();
        }

        private static OrderByOption? ParseOptionString(string optionStr)
        {
            var parts = optionStr.Split(',');
            if (parts.Length == 0)
                return null;

            var name = parts[0];
            var dir = parts.Length > 1 ? parts[1].ToLower() : "";
            return new OrderByOption
            {
                Name = name,
                Direction = dir == "desc" ? OrderByDirection.Descending : OrderByDirection.Ascending
            };
        }
    }

    public class QueryOptions
    {
        public bool IncludeRelated { get; set; }
        public OrderByOption[]? OrderBy { get; set; }
        public int Take { get; set; }
        public int Skip { get; set; }
    }
}
