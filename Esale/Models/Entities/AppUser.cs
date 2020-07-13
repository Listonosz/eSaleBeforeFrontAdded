using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace eSale.Models
{
    public class AppUser : IdentityUser
    {
        public IEnumerable<Order> Orders { get; set; }

    }
}