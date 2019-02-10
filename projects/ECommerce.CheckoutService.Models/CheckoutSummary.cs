using System;
using System.Collections.Generic;

namespace ECommerce.Checkout.Models
{
    public class CheckoutSummary
    {
        public List<CheckoutProduct> Products { get; set; }

        public double TotalPrice { get; set; }

        public DateTime Date { get; set; }
    }
}
