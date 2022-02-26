using TutorWebApi.Application.Models.Enum;

namespace TutorWebApi.Application.Models.Base
{
    public abstract class BaseQuery
    {
        public string? SearchPhrase { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string? SortBy { get; set; }
        public SortDirection SortDirection { get; set; }
    }
}
