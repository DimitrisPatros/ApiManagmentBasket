using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiManagmentBasket
{
    interface ICustomerService
    {
        bool Register(string email, string name, string address, DateTime birthDate);

        bool Update(string email, string name, string address, DateTime birthDate, bool status);

        bool Delete(string email);

        bool AddBasket(string email, Basket basket);
        bool DeleteBasket(string email, int basketId);

        List<Customer> GetRecentCustomers();
    }
}
