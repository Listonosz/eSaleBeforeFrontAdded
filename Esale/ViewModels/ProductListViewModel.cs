using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eSale.Models;

namespace eSale.ViewModels
{
    public class ProductListViewModel
    {
        public IEnumerable<Product> Products { get; set; }
        public string CurrentCategory { get; set; }

    }
}
