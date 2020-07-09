using eSale.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eSale.ViewModels
{
    public class ProductCreateViewModel
    {
        public IEnumerable<Category> Categories { get; set; }

        public Product Product { get; set; }
    }
}
