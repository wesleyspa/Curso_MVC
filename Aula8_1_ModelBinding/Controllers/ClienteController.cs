using System.Web.Mvc;
using Aula8_1_ModelBinding.Models;

namespace Aula8_1_ModelBinding.Controllers
{
    public class ClienteController : Controller
    {
        // GET: Cliente
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Cliente cliente)
        {
            //-- Model Binding vai criar uma instancia da entidade Cliente com as props preenchidas com os valores definidos 
            // na view Index e chama a Action ExibirDados, passando essa entidade.
            return View("ExibirDados", cliente);
        }

        public ActionResult ExibirDados(Cliente cliente)
        {
            return View(cliente);
        }
    }
}