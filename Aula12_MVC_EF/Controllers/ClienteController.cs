using System.Web.Mvc;
using Aula12_MVC_EF.Models;
using System.Collections.Generic;
using System.Linq;

namespace Aula12_MVC_EF.Controllers
{
    public class ClienteController : Controller
    {
        // GET: Cliente
        public ActionResult Index()
        {
            ClienteContext clienteContext = new ClienteContext();
            

            List<Cliente> clientes = clienteContext.clientes.ToList();

            return View(clientes);
        }
    }
}