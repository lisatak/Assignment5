using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Assignment5.Models;
using Assignment5.Models.ViewModels;

namespace Assignment5.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private IBooksRepository _repository;

        //set number of items displayed per page
        public int PageSize = 5;

        public HomeController(ILogger<HomeController> logger, IBooksRepository repository)
        {
            _logger = logger;
            //load private repository variable with data
            _repository = repository;
        }

        public IActionResult Index(string category, int pageNum = 1)
        {
            //default to page 1 of books

            //load view with a limited number of books at a time
            return View(new BookListViewModel
                {
                    //set Books attribute
                    Books = _repository.Books
                        .Where(b => category == null || b.Category == category)
                        .OrderBy(b => b.BookId)
                        .Skip((pageNum - 1) * PageSize)
                        .Take(PageSize),

                    //set PagingInfo attribute
                    PagingInfo = new PagingInfo
                    {
                        CurrentPage = pageNum,
                        ItemsPerPage = PageSize,
                        //determine number of pages depending on whether a category is selected
                        TotalNumItems = category == null ? _repository.Books.Count() :
                            _repository.Books.Where (x => x.Category == category).Count()
                    },

                    //set current category
                    CurrentCategory = category
                });  
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
