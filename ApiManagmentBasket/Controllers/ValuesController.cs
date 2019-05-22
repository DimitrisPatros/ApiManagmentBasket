using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using static ApiManagmentBasket.Product;

namespace ApiManagmentBasket.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private ICustomerService manager = new CustomerService();
        private ProductService basketManager = new ProductService();

        // take the customers that have been regisret the last month
        [HttpGet("/recentCustomer")]
        public List<Customer> RecentCustomers()
        {
            return manager.GetRecentCustomers();
        }

        // register new customer
        [HttpPost("/register")]
        public void Register([FromBody] Customer temp)
        {
            manager.Register(temp.Email,temp.Name,temp.Address,temp.Dob);
        }
        public struct addBasketToCustomer
        {
            public string CustomerEmail { get; set; }
            public int BasketId { get; set; }
        }

        // add basket to a customer
        [HttpPost("/addBasket")]
        public void AddBasket([FromBody] addBasketToCustomer tempbasket)
        {
            var basket =  basketManager.BasketSearch(tempbasket.BasketId);
            manager.AddBasket(tempbasket.CustomerEmail,basket.BasketThatWeSearch);
        }

        // Update existing customer
        [HttpPut("/update")]
        public void Update([FromBody] Customer temp)
        {
            manager.Update(temp.Email, temp.Name, temp.Address, temp.Dob, temp.IsActive);
        }
        // delete customer
        [HttpPut("/delete")]
        public void Delete([FromBody] string email)
        {
            manager.Delete(email);
        }

        public struct deleteBasketFromCustomer
        {
            public string CustomerEmail { get; set; }
            public int BasketId { get; set; }
        }

        [HttpDelete("/deleteBasket")]
        public void DeleteBasket([FromBody] deleteBasketFromCustomer tempbakset)
        {
            manager.DeleteBasket(tempbakset.CustomerEmail,tempbakset.BasketId);
        }
        public struct newProduct
        {
            public string ProductName { get; set; }
            public decimal Price { get; set; }
            public ProductCategoryId Category { get; set; }
        }
        // create new product
        [HttpPost("/NewProduct")]
        public void Product([FromBody] newProduct product)
        {
            //var basket = basketManager.BasketSearch(tempbasket.BasketId);
            basketManager.CreateNewProduct(product.ProductName,product.Price,product.Category);
        }
    }
}
