using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SamsStore.Models
{
    public class Product
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long UPCCodeID { get; set; }
        public string Description { get; set; }
        public float Cost { get; set; }
        public override string ToString()
        {
            return Description;
        }
    }
}