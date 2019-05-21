using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiManagmentBasket
{
    public class Data
    {

        //register new customers
        //var customer01 = service.Register("talou@hotmail.com", "toulk", "tade efi",new DateTime(1978, 5, 25));
        //var customer02 = service.Register("mpampis@hotmail.com", "Mpampis", "Marousi", new DateTime(1996, 8, 2));

        ////update current customers
        //service.Update("talou@hotmail.com", "toulkas", "kifisia", new DateTime(1978, 5, 25), true);

        ////delete customer
        //service.Delete("mpampis@hotmail.com");

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

        //service.AddBasket("talou@hotmail.com", basket01);
        //service.AddBasket("talou@hotmail.com", basket02);

        ////delete basket from a customer
        //service.DeleteBasket("talou@hotmail.com", 1);

        ////new customers

        //foreach (var customer in service.GetRecentCustomers())
        //{
        //    Console.WriteLine(customer);
        //}




        //    var context = new OrderManagmentDbContext();
        //    var baskets = context.Set<Basket>().Include(b => b.Cart).First();
        //    context.Remove(baskets.Cart.First());
        //    var totalAmount = context.Set<Product>()
        //        .Where(p => p.Category==ProductCategoryId.Shoes)
        //        .Sum(p=> p.Price);
        //    Console.WriteLine(totalAmount);
        //var Products = context.Set<Product>().ToList();
        // var baskets = context.Set<Basket>().Include(b => b.Cart).ToList();
        //foreach (var p in Products)
        //{
        //    Console.WriteLine(p);
        //}
        //basket.Cart.Add(
        //    new Product()
        //    {
        //        Name = "Jacket",
        //        Category = ProductCategoryId.Shirt,
        //        Price = 15M
        //    });
        // context.SaveChanges();
        //Console.ReadLine();
    }
}
