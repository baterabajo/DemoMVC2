
namespace DemoMVC2.ViewModel
{
    public class ProductoViewModel
    {
       public List<Models.Producto> Productos { get; set;} =new List<Models.Producto>();

       public string SearchText { get; set; }=string.Empty;
        
    }
}

