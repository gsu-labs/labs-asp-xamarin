using ASPLabs2_4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;

namespace ASPLabs2_4.Cart
{
    public class Cart
    {
        
        private List<CartLine> lineCollection = new List<CartLine>();
        public void AddItem(Electronic electronic, int quantity)
        {
            CartLine line = lineCollection
                .Where(g => g.Electronic.Id == electronic.Id)
                .FirstOrDefault();

            if (line == null)
            {
                lineCollection.Add(new CartLine
                {
                    Electronic = electronic,
                    Quantity = quantity
                });
            }
            else
            {
                line.Quantity += quantity;
            }
        }

        public void RemoveLine(Electronic electronic)
        {
            lineCollection.RemoveAll(l => l.Electronic.Id == electronic.Id);
        }

        public decimal ComputeTotalValue()
        {
            return lineCollection.Sum(e => e.Electronic.Price * e.Quantity);

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
            public Electronic Electronic { get; set; }
            public int Quantity { get; set; }
        }
    }
}