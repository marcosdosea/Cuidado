using Microsoft.AspNetCore.Mvc;

namespace CuidadoWeb.Controllers
{
    public class ManagerController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Operations(string target)
        {
            return View(nameof(Operations), target);
        }
    }
}
