using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiManagmentBasket
{
    class CustomerService : ICustomerService
    {
        //done
        public bool AddBasket(string email, Basket basket)
        {
            try
            {
                using (var context = new OrderManagmentDbContext())
                {
                    //var customerBasket = context.Set<Customer>().SingleOrDefault(c => c.Email == email);
                    //var basketquery = context.Set<Basket>().SingleOrDefault(b => b.BasketId == basket.BasketId);
                    //if (customerBasket != null && basketquery != null)
                    //{
                    //    basketquery.CustomerBelong = email;
                    //    context.SaveChanges();
                    //}
                    if (context.CustomerBaskets.Any(c => c.CustomerId.Equals(email) && c.BasketId.Equals(basket.BasketId)))
                    {
                        return false;
                    }
                    CustomerBaskets customerBasket = new CustomerBaskets()
                    {
                        BasketId = basket.BasketId,
                        CustomerId = email
                    };
                    context.CustomerBaskets.Add(customerBasket);
                    context.SaveChanges();
                    return true;
                }
            }
            catch (Exception e)
            {

                return false;
            }
        }
        //done
        public bool Delete(string email)
        {
            try
            {
                using (var context = new OrderManagmentDbContext())
                {
                    var query = context.Set<Customer>().SingleOrDefault(c => c.Email == email);
                    if (query != null)
                    {
                        query.IsActive = false;
                        context.SaveChanges();
                    }
                    else
                    {
                        Console.WriteLine("No customer with this email not found");
                    }
                    return true;
                }
            }
            catch (Exception e)
            {

                return false;
            }

        }

        //done
        public bool DeleteBasket(string email, int basketId)
        {
            try
            {
                using (var context = new OrderManagmentDbContext())
                {
                    var customerBasket = context.Set<CustomerBaskets>().SingleOrDefault(c => c.BasketId.Equals(basketId) && c.CustomerId.Equals(email));
                    if (customerBasket != null)
                    {
                        context.Remove(customerBasket);
                        var basket = context.Set<Basket>().SingleOrDefault(b => b.BasketId.Equals(basketId));
                        context.Remove(basket);
                        context.SaveChanges();
                    }
                    return true;
                }
            }
            catch (Exception e)
            {
                return false;
            }
        }
        //done
        public List<Customer> GetRecentCustomers()
        {

            using (var context = new OrderManagmentDbContext())
            {
                var customerList = new List<Customer>();
                customerList = context.Set<Customer>()
                    .Where(t => t.RegisterDay.AddDays(30) >= DateTime.Today)
                    .Where(t => t.IsActive == true)
                    .ToList();
                //this return all the customer that have been registered the last month
                return customerList;
            }

        }

        //done
        public bool Register(string email, string name, string address, DateTime birthDate)
        {
            using (var context = new OrderManagmentDbContext())
            {
                var newCustomer = new Customer(email, name, address, true, birthDate);
                context.Add(newCustomer);
                context.SaveChanges();
                return true;
            }
        }

        //done
        public bool Update(string email, string name, string address, DateTime birthDate, bool status)
        {
            try
            {
                using (var context = new OrderManagmentDbContext())
                {
                    var query = context.Set<Customer>().SingleOrDefault(c => c.Email == email);
                    if (query != null)
                    {
                        query.Email = email;
                        query.Name = name;
                        query.Address = address;
                        query.Dob = birthDate;
                        query.IsActive = status;
                        context.SaveChanges();
                    }
                    return true;
                }
            }
            catch (Exception e)
            {

                return false;
            }
        }
    }
}
