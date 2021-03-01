using Assignment5.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment5.Components
{
    public class NavigationMenuViewComponent : ViewComponent
    {
        private IBooksRepository repository;
        public NavigationMenuViewComponent (IBooksRepository r)
        {
            repository = r;
        }
        public IViewComponentResult Invoke()
        {
            //holds the selected category for routing
            ViewBag.SelectedCategory = RouteData?.Values["category"];

            //gets all distinct cateogries for menu view component
            return View(repository.Books
                .Select(x => x.Category)
                .Distinct()
                .OrderBy(x => x));
        }
    }
}
