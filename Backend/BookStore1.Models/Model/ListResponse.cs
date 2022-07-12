using BookStore1.Models.Models;
using System.Collections.Generic;

namespace BookStore1.Models.Model
{
    public class ListResponse<T> where T : class
    {
        public IEnumerable<T> Results { get; set; }

        public int TotalRecords { get; set; }
    }
}
