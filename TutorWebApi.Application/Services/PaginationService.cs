using TutorWebApi.Application.Interfaces;
using TutorWebApi.Application.Models.Enum;

namespace TutorWebApi.Application.Services
{
    public class PaginationService : IPaginationService
    {     
        public List<T> ReturnRecordsToShow<T>(int pageNumber, int pageSize, List<T> list)
        {
            var excludeRecords = GetExcludeRecordsToPagination(pageNumber, pageSize);

            var records = list.Skip(excludeRecords)
                .Take(pageSize)
                .ToList();

            return records;
        }

        private int GetExcludeRecordsToPagination(int pageNumber, int pageSize)
        {
            var result = pageSize * (pageNumber - 1);
            return result;
        }

        public List<T> SortRecords<T>(Func<T, object> sortedFunc, SortDirection sortDirection, List<T> baseQuery)
        {
            if(sortDirection == SortDirection.ASC)
            {
                baseQuery = baseQuery.OrderBy(sortedFunc).ToList();
            }
            else
            {
                baseQuery = baseQuery.OrderByDescending(sortedFunc).ToList();
            }
            return baseQuery;
        }
    }
}
