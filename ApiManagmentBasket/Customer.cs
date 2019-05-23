using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApiManagmentBasket
{
    public class Customer
    {
        [Key]
        [MaxLength(150)]
        public string Email { get; set; }// unque & require
        public string Name { get; set; } //require
        public string Address { get; set; }
        public bool IsActive { get; set; }
        public DateTime Dob { get; set; }
        public DateTime RegisterDay { get; set; }
        public List<CustomerBaskets> customerBaskets { get; set; }

        public Customer(string email, string name, string address, bool isActive, DateTime dob) //: this(email, name)
        {
            Email = email;
            Name = name;
            Address = address;
            IsActive = isActive;
            Dob = dob;
            RegisterDay = DateTime.Today;
            customerBaskets = new List<CustomerBaskets>();
        }
        //public Customer(string name, string email)
        //{
        //    Name = name;
        //    Email = email;
        //    IsActive = true;
        //}
        public override string ToString()
        {
            return $"{Name}:{Address}:{Email}:{IsActive},{Dob}";
        }






    }
}
