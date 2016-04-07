using System.Web.Mvc;
using Aula_5.Models;

namespace Aula_5.Controllers
{
    public class ClienteController : Controller
    {

        public ActionResult Index()
        {
            return View();
        }

        // GET: Cliente
        public ActionResult Detalhe()
        {
            //-- Lógica de acesso aos dados usando entididades
            //-- ADO.NET, EF, NHibernate

            Cliente cliente = new Cliente()
            {
                ClienteId = 100,
                Nome = "Wesley",
                Email = "Wesleyspa@yahoo.com.br",
                Telefone = "33221221"
            };


            return View(cliente);
        }

        //public ActionResult SalvarCliente(int ClienteId, string Nome, string Email, string Telefone)
        //public ActionResult SalvarCliente(FormCollection Cli)
        [HttpPost]
        public ActionResult SalvarCliente(Cliente cliente)

        {
            //ViewBag.ClienteId = Cli["ClienteId"];
            //ViewBag.Nome = Cli["Nome"];

            ViewBag.ClienteId = cliente.ClienteId;
            ViewBag.Nome = cliente.Nome;

            return View(cliente);
        }
    }
}