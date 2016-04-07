using System.Web.Mvc;

namespace Aula_11_2_MVC_FormCollection.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(FormCollection formulario)
        {
            foreach (string chave in formulario)
            {
                Response.Write("Chave = " + chave + " ");
                Response.Write("Valor = " + formulario[chave]);
                Response.Write("<br />");
                Response.Write("<br />");

            }

            return View();
        }

        public void SalvarCliente(FormCollection form1)
        {
            string Nome = form1["nome"];
            string Email = form1["email"];
            string Telefone = form1["telefone"];
            int Idade = int.Parse(form1["idade"]);

        }
    }
}