using System.Collections.Generic;

namespace ApiManagmentBasket
{
    public class Basket
    {
        public int BasketId { get; set; }
        public string CustomerBelong { get; set; }

        public List<Product> Cart { get; set; }

        public Basket()
        {
            Cart = new List<Product>();
        }
    }
}