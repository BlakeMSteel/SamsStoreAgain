using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SamsStore.Models
{
    public class Customer
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Purchase LastPurchase { get; set; }

        public virtual ICollection<Purchase> Purchases { get; set; }
        public override string ToString()
        {
            return $"{FirstName} {LastName}";
        }
    }
}