using Microsoft.AspNetCore.Mvc;

namespace Aula2407.Controllers
{
    public class NossoAppController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
