namespace SchoolProject.Core.Wrappers
{
    public class PaginatedResult<T>
    {
        public PaginatedResult(List<T> data)
        {
            Data = data ?? new List<T>();
        }

        public PaginatedResult(bool succeeded, List<T>? data = null,
                List<string>? messages = null, int count = 0, int page = 1, int pageSize = 10)
        {
            Succeeded = succeeded;
            Data = data ?? new List<T>();
            CurrentPage = page;
            PageSize = pageSize;
            TotalCount = count;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);
        }

        public static PaginatedResult<T> Success(List<T> data, int count, int page,
            int pagesize)
        {
            return new PaginatedResult<T>(true, data, null, count, page, pagesize);
        }

        public List<T> Data { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public int TotalCount { get; set; }
        public object? Meta { get; set; }
        public int PageSize { get; set; }
        public bool HasPreviosPage => CurrentPage > 1;
        public bool HasNextPage => CurrentPage < TotalCount;
        public List<string> Messages { get; set; } = new List<string>();
        public bool Succeeded { get; set; }
    }
}
