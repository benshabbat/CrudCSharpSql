using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace CrudCSharpSql.Pages.Colors
{
    public class Index : PageModel
    {

        public void OnGet()
        {
        }
    }

    public class ColorInfo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        
        public double Price { get; set; }

        public bool IsInStock { get; set; }
    }
}