using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eSale.Models.Entities
{
    public class Adress
    {
        public int AdressId { get; set; }
        public string HomeStreet { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
        public Order Order { get; set; }
    }
}
