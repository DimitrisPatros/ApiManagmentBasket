using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static ApiManagmentBasket.Product;

namespace ApiManagmentBasket
{
    public class ProductService
    {
        public struct SearcBasket
        {
            public bool QueryResault { get; set; }
            public Basket BasketThatWeSearch { get; set; }
        }
        public SearcBasket BasketSearch(int basketId)
        {
            var tempBasket = new SearcBasket();
            try
            {
                using (var context = new OrderManagmentDbContext())
                {
                    var basketquery = context.Set<Basket>().SingleOrDefault(b => b.BasketId == basketId);
                    if (basketquery != null)
                    {
                        tempBasket.BasketThatWeSearch = basketquery;
                        tempBasket.QueryResault = true;
                        return tempBasket;
                    }
                    else
                    {
                        tempBasket.BasketThatWeSearch = null;
                        tempBasket.QueryResault = false;
                        return tempBasket;
                    }
                }
            }
            catch (Exception e)
            {
                tempBasket.BasketThatWeSearch = null;
                tempBasket.QueryResault = false;
                return tempBasket;
            }
        }

        public bool CreateNewProduct(string name, decimal price, ProductCategoryId categoryid)
        {
            using (var context = new OrderManagmentDbContext())
            {
                var newProduct = new Product();
                newProduct.Name = name;
                newProduct.Price = price;
                newProduct.Category = categoryid;
                context.Add(newProduct);
                context.SaveChanges();
                return true;
            }
        }


    }
}


////add baskets to a customer

//var basket01 = new Basket();
//var basket02 = new Basket();
//var p1 = new Product()
//{
//    Name = "addidas Shoes",
//    Category = ProductCategoryId.Shoes,
//    Price = 125.22M
//};
//var p2 = new Product()
//{
//    Name = "Nike Shoes",
//    Category = ProductCategoryId.Shoes,
//    Price = 105.22M
//};
//var p3 = new Product()
//{
//    Name = "gap",
//    Category = ProductCategoryId.Shirt,
//    Price = 55.22M
//};

//basket01.Cart.Add(p1);
//basket01.Cart.Add(p2);
//basket02.Cart.Add(p1);
//basket02.Cart.Add(p2);
//basket02.Cart.Add(p3);
//var context = new OrderManagmentDbContext();
//context.Add(basket01);
//context.Add(basket02);
//context.SaveChanges();