using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace DemoMVC2.Views.Prueba
{
    public class Prueba : PageModel
    {
        private readonly ILogger<Prueba> _logger;

        public Prueba(ILogger<Prueba> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }
}