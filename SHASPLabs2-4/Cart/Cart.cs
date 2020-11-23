using SHASPLabs2_4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SHASPLabs2_4.Cart
{
    public class Cart
    {
        private List<CartLine> lineCollection = new List<CartLine>();
        public void AddItem(Juice juice, int quantity)
        {
            CartLine line = lineCollection
                .Where(g => g.Juice.Id == juice.Id)
                .FirstOrDefault();

            if (line == null)
            {
                lineCollection.Add(new CartLine
                {
                    Juice = juice,
                    Quantity = quantity
                });
            }
            else
            {
                line.Quantity += quantity;
            }
        }

        public void RemoveLine(Juice juice)
        {
            lineCollection.RemoveAll(l => l.Juice.Id == juice.Id);
        }

        public decimal ComputeTotalValue()
        {
            return lineCollection.Sum(e => e.Juice.Price * e.Quantity);

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
            public Juice Juice { get; set; }
            public int Quantity { get; set; }
        }
    }
}