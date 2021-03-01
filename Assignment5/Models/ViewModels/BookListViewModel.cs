using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment5.Models.ViewModels
{
    public class BookListViewModel
    {
        //Books to displlay information for each book
        public IEnumerable<Books> Books { get; set; }
        //Paging info for navigation at bottom of page
        public PagingInfo PagingInfo { get; set; }

    }
}
