using TutorWebApi.Application.Models.Enum;

namespace TutorWebApi.Application.Models.Advert
{
    public class AdvertQuery
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string? SearchPhrase { get; set; }
        public string? SortBy { get; set; }
        public SortDirection SortDirection { get; set; }
    }
}
