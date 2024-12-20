using DemoMVC2.Data;
using DemoMVC2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DemoMVC2.ViewModel;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;
using Microsoft.VisualStudio.Web.CodeGeneration.CommandLine;



namespace DemoMVC2.Controllers
{
    //[Route("[controller]/[action]")]
    //[ApiController]
    public class ProductoController : Controller
    {
        private readonly DataContext _context;

        public ProductoController(DataContext context)
        {
            _context = context;
        }

        //    [Route("~/")]
        //   [Route("~/Producto/Index")]
        //[HttpGet]
        /*
        public IActionResult Index()
        {
            var productos = _context.Productos!.Include(p => p.Categoria).Include(p => p.Proveedor).ToList();

            return View(productos);
        }
        */

        //[Route("~/Producto/Index/{SearchText?}")]
        //[Route("api/[controller]/[action]/{SearchText?}")]
       // [HttpGet("{SearchText}")]
        public IActionResult Index(string SearchText)
        {
            var productos = _context.Productos!.Include(p => p.Categoria).Include(p => p.Proveedor).ToList();

            if (!string.IsNullOrEmpty(SearchText))
            {
                productos = productos.Where(p => p.Nombre!.Contains(SearchText)).ToList();
            }

            var productoViewModel = new ProductoViewModel();
            productoViewModel.SearchText = SearchText;

            productoViewModel.Productos = productos;

            return View(productoViewModel);

        }



        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ViewBag.Categoria = await _context.Categorias!.ToListAsync();
            ViewBag.Proveedor = await _context.Proveedors!.ToListAsync();

            return View();
        }



        //[HttpPost("{Id,Nombre,Descripcion,Precio,CategoriaId,ProveedorId}")]
        //[Route("~/")]
        //[Route("~/Producto/Index")]

        //[Route("api/[controller]/[action]/{Id,Nombre,Descripcion,Precio,CategoriaId,ProveedorId}")]

        [HttpPost]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Descripcion,Precio,CategoriaId,ProveedorId")] Producto producto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(producto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));

            }

            ViewBag.Categoria = await _context.Categorias!.ToListAsync();
            ViewBag.Proveedor = await _context.Proveedors!.ToListAsync();

            return View(producto);
        }

        //[HttpGet("{id}")]
        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var producto = await _context.Productos!.FindAsync(id);

            if (id == null)
            {
                return NotFound();
            }


            ViewBag.Categoria = await _context.Categorias!.ToListAsync();
            ViewBag.Proveedor = await _context.Proveedors!.ToListAsync();

            return View(producto);
        }

        //[HttpPost("{Id,Nombre,Descripcion,Precio,CategoriaId,ProveedorId}")]
        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Descripcion,Precio,CategoriaId,ProveedorId")] Producto producto)
        {
            if (id != producto.Id)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(producto);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));

                }
                catch (Exception ex)
                {
                    string msg = ex.Message;
                }
            }

            ViewBag.Categoria = await _context.Categorias!.ToListAsync();
            ViewBag.Proveedor = await _context.Proveedors!.ToListAsync();

            return View(producto);
        }


        //[HttpGet("{id}")]

        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
            {
                if (id == null)
                {
                    return NotFound();
                }

                var productoDB = await _context.Productos!.FindAsync(id);

                if (productoDB == null)
                {
                    return NotFound();
                }

                try
                {
                    _context.Productos.Remove(productoDB);
                    await _context.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    string message = ex.Message;
                }
                return RedirectToAction(nameof(Index));

            }


        //[HttpGet("{id}")]
        [HttpGet]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productoDB = await _context.Productos!
                .Include(p => p.Categoria)
                .Include(p => p.Proveedor)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (productoDB == null)
            {
                return NotFound();
            }

            return View(productoDB);

        }


    }
        
}