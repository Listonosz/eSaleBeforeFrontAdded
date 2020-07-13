using eSale.Models.Entities;
using Microsoft.AspNetCore.DataProtection.KeyManagement;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace eSale.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public int? AdressId { get; set; }
        public string UserId { get; set; }
        public decimal OrderTotal { get; set; }
        public DateTime? OrderDate { get; set; }
        public string FirstName { get; set; }
        public string PhoneNumber { get; set; }
        [ForeignKey("UserId")]
        public virtual AppUser AppUser { get; set; }
        public Adress Adress { get; set; }
        public List<OrderItem> OrderItems { get; set; }

    }
}
