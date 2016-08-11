using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SamsStore.Models
{
    public class Department
    {
        public int DepartmentID { get; set; }
        public string Name { get; set; }
        public Employee DepartmentManager { get; set; }
        public ICollection<Employee> Employees { get; set; }
        public ICollection<Product> Products { get; set; }
        public ICollection<Purchase> RecentPurchases { get; set; }
        public Dictionary<Product, int> Inventory { get; set; }
        public override string ToString()
        {
            return $"{Name}, managed by {DepartmentManager}";
        }
    }
}