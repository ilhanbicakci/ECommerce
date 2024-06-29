using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities.Models
{
    public class GenericPagination<T> where T : class
    {
        public IEnumerable<T> Data { get; set; }
        public int CurrentPage { get; set; }
        public int PerPage { get; set; }
        public int TotalPage { get; set; }
        public int TotalItem { get; set; }
        public int Start { get; set; }
        public int End { get; set; }

        public GenericPagination(IEnumerable<T> allData, int currentPage, int perPage, int limit = 2)
        {
            CurrentPage = currentPage;
            PerPage = perPage;
            TotalItem = allData.Count();
            TotalPage = (int)Math.Ceiling(allData.Count() / (double)perPage);
            Start = CurrentPage - limit <= 1 ? 1 : CurrentPage - limit;
            End = CurrentPage + limit >= TotalPage ? TotalPage : CurrentPage + limit;
            Data = allData.Skip((CurrentPage - 1) * perPage).Take(perPage);
        }
    }
}
