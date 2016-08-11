namespace SamsStore.Migrations
{
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<SamsStore.DAL.StoreContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(SamsStore.DAL.StoreContext context)
        {
            var products = new List<Product>
            {
                new Product { Description = "Totally not cigarettes", Cost = 10.00F, UPCCodeID = 1234567890 },
                new Product { Description = "Totally not alcohol", Cost = 5.50F, UPCCodeID = 2345678901 },
                new Product { Description = "Totally not weed", Cost = 15.23F, UPCCodeID = 3456789012 },
                new Product { Description = "Totally not cocaine", Cost = 20.00F, UPCCodeID = 4567890123 },
                new Product { Description = "Totally not lsd", Cost = 85.39F, UPCCodeID = 5678901234 },
            };
            products.ForEach(p => context.Products.Add(p));
            context.SaveChanges();
            var employees = new List<Employee>
            {
                new Employee { FirstName = "Ashley", LastName = "Steel", HireDate=DateTime.Parse("2003-09-01"), Wage = 8.50F },
                new Employee { FirstName = "Athena", LastName = "Steel", HireDate=DateTime.Parse("2003-09-01"), Wage = 8.50F },
                new Employee { FirstName = "Helen", LastName = "Keller", HireDate=DateTime.Parse("2003-09-01"), Wage = 8.50F },
                new Employee { FirstName = "Victoria", LastName = "Secret", HireDate=DateTime.Parse("2003-09-01"), Wage = 8.50F }
            };
            employees.ForEach(e => context.Employees.Add(e));
            context.SaveChanges();
            
            var purchases = new List<Purchase>
            {
                new Purchase { ProductID = 1234567890, PaymentType = PaymentType.Cash, PurchaseDate = DateTime.Parse("2003-09-01"), Product = context.Products.Where(p => p.UPCCodeID == 1234567890).FirstOrDefault() },
                new Purchase { ProductID = 2345678901, PaymentType = PaymentType.Check, PurchaseDate = DateTime.Parse("2003-09-01"), Product = context.Products.Where(p => p.UPCCodeID == 2345678901).FirstOrDefault() },
                new Purchase { ProductID = 3456789012, PaymentType = PaymentType.Credit, PurchaseDate = DateTime.Parse("2003-09-01"), Product = context.Products.Where(p => p.UPCCodeID == 3456789012).FirstOrDefault() },
                new Purchase { ProductID = 4567890123, PaymentType = PaymentType.Debit, PurchaseDate = DateTime.Parse("2003-09-01"), Product = context.Products.Where(p => p.UPCCodeID == 4567890123).FirstOrDefault() }
            };
            purchases.ForEach(p => context.Purchases.Add(p));
            context.SaveChanges();
            var departments = new List<Department>
            {
                new Department
                {
                    Name = "Legal Drugs",
                    DepartmentManager = context.Employees.Where(e => e.FirstName == "Ashley").FirstOrDefault(),
                    Employees = { context.Employees.Where(e => e.FirstName == "Athena").FirstOrDefault(), context.Employees.Where(e => e.FirstName == "Ashley").FirstOrDefault() },
                    Products = { context.Products.Where(p => p.Description == "Totally not cigarettes").FirstOrDefault(), context.Products.Where(p => p.Description == "Totally not alcohol").FirstOrDefault() },
                    Inventory = { { context.Products.Where(p => p.Description == "Totally not cigarettes").FirstOrDefault(), 10 }, { context.Products.Where(p => p.Description == "Totally not alcohol").FirstOrDefault(), 10 } },
                    RecentPurchases = { context.Purchases.Where(p => p.PurchaseID == 1).FirstOrDefault(), context.Purchases.Where(p => p.PurchaseID == 2).FirstOrDefault() }
                },
                new Department
                {
                    Name = "Still Legal Drugs I Promise",
                    DepartmentManager = context.Employees.Where(e => e.FirstName == "Helen").FirstOrDefault(),
                    Employees = { context.Employees.Where(e => e.FirstName == "Helen").FirstOrDefault(), context.Employees.Where(e => e.FirstName == "Victoria").FirstOrDefault() },
                    Products = { context.Products.Where(p => p.Description == "Totally not weed").FirstOrDefault(), context.Products.Where(p => p.Description == "Totally not cocaine").FirstOrDefault(), context.Products.Where(p => p.Description == "Totally not lsd").FirstOrDefault() },
                    Inventory = { { context.Products.Where(p => p.Description == "Totally not weed").FirstOrDefault(), 10 }, { context.Products.Where(p => p.Description == "Totally not cocaine").FirstOrDefault(), 10 }, { context.Products.Where(p => p.Description == "Totally not lsd").FirstOrDefault(), 10 } },
                    RecentPurchases = { context.Purchases.Where(p => p.PurchaseID == 3).FirstOrDefault(), context.Purchases.Where(p => p.PurchaseID == 4).FirstOrDefault() }
                }
            };
            departments.ForEach(d => context.Departments.Add(d));
            context.SaveChanges();
            var customers = new List<Customer>
            {
                new Customer
                {
                    FirstName = "Blake",
                    LastName = "Steel",
                    LastPurchase = context.Purchases.Where(p => p.PurchaseID == 2).FirstOrDefault(),
                    Purchases = { context.Purchases.Where(p => p.PurchaseID == 1).FirstOrDefault(), context.Purchases.Where(p => p.PurchaseID == 2).FirstOrDefault() }
                },
                new Customer
                {
                    FirstName = "Sydney",
                    LastName = "Krajewski",
                    LastPurchase = context.Purchases.Where(p => p.PurchaseID == 4).FirstOrDefault(),
                    Purchases = { context.Purchases.Where(p => p.PurchaseID == 3).FirstOrDefault(), context.Purchases.Where(p => p.PurchaseID == 4).FirstOrDefault() }
                }
            };
            customers.ForEach(c => context.Customers.Add(c));
            context.SaveChanges();
        }
    }
}
