using BookManagerModelsLibrary.BookModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookManagerModelsLibrary.CartModels
{
    public class CartModel
    { 
        public CartItem CartItem { get; set; }
        public decimal CartTotal { get; set; }
        public int TotalCartItems { get; set; }
    }
}
