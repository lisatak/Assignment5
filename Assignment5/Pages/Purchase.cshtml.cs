using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assignment5.Infrastructure;
using Assignment5.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Assignment5.Pages
{
    public class PurchaseModel : PageModel
    {
        private IBooksRepository repository;

        //Constructor
        public PurchaseModel (IBooksRepository repo, Cart cartService)
        {
            repository = repo;
            Cart = cartService;
        }

        //Properties
        public Cart Cart { get; set; }
        public string ReturnUrl { get; set; }
        
        //Methods
        //to return to last shopping page
        public void OnGet(string returnUrl)
        {
            ReturnUrl = returnUrl ?? "/";
        }

        //add line to cart
        public IActionResult OnPost(int bookId, string returnUrl)
        {
            Books book = repository.Books.FirstOrDefault(b => b.BookId == bookId);

            Cart.AddItem(book, 1);

            return RedirectToPage(new { returnUrl = returnUrl });
        }

        //remove a line from cart
        public IActionResult OnPostRemove(int bookId, string returnUrl)
        {
            Cart.RemoveLine(Cart.Lines.First(b =>
                b.Book.BookId == bookId).Book);
            return RedirectToPage(new { returnUrl = returnUrl });
        }
    }
}
