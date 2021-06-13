using BookManagerModelsLibrary.BookModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookManagerModelsLibrary.CartModels
{
    public class CartItem
    {
        public string Isbn { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public decimal CartItemTotal { get; set; }
    }
}
