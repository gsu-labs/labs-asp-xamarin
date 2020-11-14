using SASPLabs_2_4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SASPLabs_2_4.Cart
{
    public class Cart
    {
        private List<CartLine> lineCollection = new List<CartLine>();
        public void AddItem(Waffle waffle, int quantity)
        {
            CartLine line = lineCollection
                .Where(g => g.Waffle.Id == waffle.Id)
                .FirstOrDefault();

            if (line == null)
            {
                lineCollection.Add(new CartLine
                {
                    Waffle = waffle,
                    Quantity = quantity
                });
            }
            else
            {
                line.Quantity += quantity;
            }
        }

        public void RemoveLine(Waffle waffle)
        {
            lineCollection.RemoveAll(l => l.Waffle.Id == waffle.Id);
        }

        public decimal ComputeTotalValue()
        {
            return lineCollection.Sum(e => e.Waffle.Price * e.Quantity);

        }
        public void Clear()
        {
            lineCollection.Clear();
        }

        public IEnumerable<CartLine> Lines
        {
            get { return lineCollection; }
        }

        public class CartLine
        {
            public Waffle Waffle { get; set; }
            public int Quantity { get; set; }
        }
    }
}