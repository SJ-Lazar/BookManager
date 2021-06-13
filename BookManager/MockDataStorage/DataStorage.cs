using BookManagerModelsLibrary.CartModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookManager.MockDataStorage
{
    public static class DataStorage
    {
        public static List<CartItem> GetAllCartItems() =>
            new List<CartItem>
            {
                new CartItem { Isbn="1234567890", Price=120.00M, Quantity=2, CartItemTotal=240.00M },
                new CartItem { Isbn="2234567890", Price=50.50M, Quantity=3, CartItemTotal=101.00M },
                new CartItem { Isbn="3234567890", Price=125.99M, Quantity=1, CartItemTotal=125.99M }
            };
    }
}
