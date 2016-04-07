using System.Web.Mvc;

namespace Atividade2.Controllers
{
    public class Atividade2Controller : Controller
    {
        // GET: Atividade2
        public ActionResult Index()
        {
            ViewData["Nome"] = "Wesley";
            ViewBag.Atividade = "Atividade 2";
            ViewBag.Curso = "Curso ASP.NET MVC 5";

            return View();
        }
    }
}