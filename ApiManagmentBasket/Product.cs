using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiManagmentBasket
{
    public class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public ProductCategoryId Category { get; set; }
        public Product()
        {
        }
        public override string ToString()
        {
            return $"{ProductId}:{Name}:{Price}:{Category.ToString()}";
        }
        public enum ProductCategoryId
        {
            Shirt = 1,
            Shoes = 2,
            Jeans = 3,
            Bags = 4
        }
    }
}
