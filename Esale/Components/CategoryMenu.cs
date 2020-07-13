using eSale.Data;
using eSale.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eSale.Components
{
    public class CategoryMenu : ViewComponent
    {
        private readonly eSaleDbContext _eSaleDbContext;

        public CategoryMenu(eSaleDbContext __eSaleDbContext)
        {
            _eSaleDbContext = __eSaleDbContext;
        }

        public IViewComponentResult Invoke()
        {
            var categories = _eSaleDbContext.Categories.Where(cat => cat.CategoryId != 1).OrderBy(c => c.CategoryName);
            return View(categories);
        }
    }
}
