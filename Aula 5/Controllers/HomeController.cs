using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Aula_5.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        //public string Index()
        public ActionResult Index()
        {
            //ViewData["Nome"] = "Wesley";
            //ViewData["Data"] = new DateTime();

            ViewBag.Nome = "Wesley - ViewBag";
            ViewBag.Data = new DateTime(1);

            ViewBag.Paises = new List<String>() {
                "Brasil",
                "Argentina",
                "Estados Unidos"
            };

            return View();
            //return "Retorno da Controller Home";
        }

        public string Inicio()
        {
            return "Minha primeira aplicação MVC";
        }
        
        public string Saudacao(int Id)
        {
            return String.Format("Código recebido da url = {0}", Id);
        }
    }
}