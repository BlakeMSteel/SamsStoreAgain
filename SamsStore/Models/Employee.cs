using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SamsStore.Models
{
    public class Employee
    {
        public int EmployeeID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public float Wage { get; set; }
        public DateTime HireDate { get; set; }
        public override string ToString()
        {
            return $"{FirstName} {LastName}";
        }
    }
}