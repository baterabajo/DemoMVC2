
using DemoMVC2.Data;
using Microsoft.AspNetCore.Mvc;


namespace DemoMVC2.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PruebaController : Controller
    {
        private readonly DataContext _context;
 
        public PruebaController(DataContext context)
        {

            _context=context;
        }

        public IActionResult Prueba()
        {
        //var streamers=_context.streamers!.ToList();

        //return View(streamers);

         return View();
       
        }

    }
}