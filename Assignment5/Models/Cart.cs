using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment5.Models
{
    public class Cart
    {
        public List<CartLine> Lines { get; set; } = new List<CartLine>();

        public void AddItem (Books book, int quantity)
        {
            CartLine line = Lines
                  .Where(b => b.Book.BookId == book.BookId)
                  .FirstOrDefault();

            if (line == null)
            {
                Lines.Add(new CartLine
                {
                    Book = book,
                    Quantity = quantity,
                });
            }
            else
            {
                line.Quantity += quantity;
            }
        }

        public void RemoveLine(Books book) =>
            Lines.RemoveAll(x => x.Book.BookId == book.BookId);

        public void Clear() => Lines.Clear();

        public decimal ComputeTotalSum() => Lines.Sum(e => 25 * e.Quantity);

        public class CartLine
        {
            public int CartLineID { get; set; }
            public Books Book { get;set; }
            public int Quantity { get; set; }

        }
    }
}
