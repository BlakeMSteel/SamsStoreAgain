using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SamsStore.Models
{
    public enum PaymentType
    {
        Credit,
        Debit,
        Cash,
        Check
    }
    public class Purchase
    {
        public int PurchaseID { get; set; }
        public long ProductID { get; set; }
        public PaymentType PaymentType { get; set; }
        public DateTime PurchaseDate { get; set; }

        public virtual Product Product { get; set; }

        public override string ToString()
        {
            return $"{Product} bought on {PurchaseDate} with {PaymentType}.";
        }
    }
}