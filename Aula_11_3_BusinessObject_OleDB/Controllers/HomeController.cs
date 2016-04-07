using System;
using System.Web.Mvc;
using System.Linq;
using System.Web;
using Aula_11_3_BO_BLL;
using System.Collections.Generic;

namespace Aula_11_3_BusinessObject_OleDB.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            AlunoBLL _aluno = new AlunoBLL();

            List<Aluno> alunos = _aluno.getAlunos().ToList();

            return View(alunos);
        }
    }
}