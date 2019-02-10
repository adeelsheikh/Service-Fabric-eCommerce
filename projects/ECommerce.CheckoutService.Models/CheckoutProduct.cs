﻿using ECommerce.ProductCatalog.Models;

namespace ECommerce.Checkout.Models
{
    public class CheckoutProduct
    {
        public Product Product { get; set; }

        public int Quantity { get; set; }

        public double Price { get; set; }
    }
}
