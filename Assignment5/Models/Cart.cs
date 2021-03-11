using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment5.Models
{
    public class Cart
    {
        //properties
        public List<CartLine> Lines { get; set; } = new List<CartLine>();

        //methods
        //add item to cart
        public virtual void AddItem (Books book, int quantity)
        {
            //check if book has already been added to cart
            CartLine line = Lines
                  .Where(b => b.Book.BookId == book.BookId)
                  .FirstOrDefault();
            //set quantity to one if not already added
            if (line == null)
            {
                Lines.Add(new CartLine
                {
                    Book = book,
                    Quantity = quantity,
                });
            }
            //increase quantity if book was already added
            else
            {
                line.Quantity += quantity;
            }
        }

        //remove item from cart
        public virtual void RemoveLine(Books book) =>
            Lines.RemoveAll(x => x.Book.BookId == book.BookId);

        //clear cart
        public virtual void Clear() => Lines.Clear();

        //calculate subtotal
        public decimal ComputeTotalSum() => (decimal)Lines.Sum(e => e.Book.Price * e.Quantity);

        //a line for each book in the cart
        public class CartLine
        {
            public int CartLineID { get; set; }
            public Books Book { get;set; }
            public int Quantity { get; set; }

        }
    }
}
