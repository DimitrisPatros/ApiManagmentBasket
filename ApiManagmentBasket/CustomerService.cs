using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiManagmentBasket
{
        class CustomerService : ICustomerService
        {
            public bool AddBasket(string email, Basket basket)
            {
                try
                {
                    using (var context = new OrderManagmentDbContext())
                    {
                        var query = context.Set<Customer>().SingleOrDefault(c => c.Email == email);
                        var basketquery = context.Set<Basket>().SingleOrDefault(b => b.BasketId == basket.BasketId);
                        if (query != null && basketquery != null)
                        {
                            basketquery.CustomerBelong = email;
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

            public bool DeleteBasket(string email, int basketId)
            {
                try
                {
                    using (var context = new OrderManagmentDbContext())
                    {
                        var query = context.Set<Customer>().SingleOrDefault(c => c.Email == email);
                        if (query != null)
                        {
                            //var basketquery = context.Set<Basket>().SingleOrDefault(b => b.BasketId == basket.BasketId);
                            var basketRemover = context.Set<Basket>().SingleOrDefault(b => b.BasketId == basketId);
                            basketRemover.CustomerBelong = null;
                            context.Remove(basketRemover);
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
