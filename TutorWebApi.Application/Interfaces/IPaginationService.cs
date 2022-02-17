using TutorWebApi.Application.Models.Enum;

namespace TutorWebApi.Application.Interfaces
{
    public interface IPaginationService
    {
        public List<T> ReturnRecordsToShow<T>(int pageNumber, int pageSize, List<T> list);
        public List<T> SortRecords<T>(Func<T, object> sortedFunc, SortDirection sortDirection, List<T> baseQuery);
    }
}
