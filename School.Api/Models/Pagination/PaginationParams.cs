namespace School.Api.Models.Pagination
{
    public class PaginationParams
    {
        private const int MaxPageSize = 10;
        private int _PageSize = 2;
        public int Page { get; set; } = 1;
        public int PageSize
        {
            get => _PageSize;
            set => _PageSize = value > MaxPageSize ? MaxPageSize : value;
        }
    }
}
