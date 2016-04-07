using System.Web.Mvc;
using Atividade3_MVC_Produto.Models;

namespace Atividade3_MVC_Produto.Controllers
{
    public class ProdutoController : Controller
    {
        // GET: Produto
        public ActionResult Produtos()
        {
            Produto produto = new Produto()
            {
                ProdutId = 5,
                Nome = "Curso MVC",
                Descricao = "ASP.NET MVC 5"                
            };

            return View(produto);
        }
    }
}