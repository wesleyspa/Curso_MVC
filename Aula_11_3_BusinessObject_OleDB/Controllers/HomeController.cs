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

        //-- GET
        public ActionResult Create()
        {

            return View();
        }

        [HttpPost]
        [ActionName("Create")] 
        public ActionResult Create_Post()
        {
            //Aluno aluno = new Aluno();
            //aluno.Nome = formulario["Nome"];
            //aluno.Email = formulario["Email"];
            //aluno.Idade = Convert.ToInt32(formulario["Idade"]);
            //aluno.DataInscricao = Convert.ToDateTime(formulario["DataInscricao"]);
            //aluno.Sexo = formulario["Sexo"];

            if (ModelState.IsValid)
            {
                Aluno aluno = new Aluno();
                //-- Preenche os dados do Aluno com os objetos da View (como se fosse um formCollections automatico)
                //UpdateModel(aluno); ou 
                TryUpdateModel(aluno);
                //-- Ou posso receber o Aluno aluno já no parâmetro do método

                AlunoBLL alunoBll = new AlunoBLL();
                alunoBll.IncluirAluno(aluno);

                return RedirectToAction("Index");
            }

            return View();
        }        

        public ActionResult Edit(int Id)
        {
            AlunoBLL alunoBll = new AlunoBLL();
            Aluno aluno = alunoBll.getAlunos().Single(x => x.Id == Id);          
            return View(aluno);
        }

        //[HttpPost]
        //[ActionName("Edit")]
        //public ActionResult Edit_Post(int Id)
        //{
        //    AlunoBLL alunoBll = new AlunoBLL();
        //    Aluno aluno = alunoBll.getAlunos().Single(x => x.Id == Id);
        //    //TryUpdateModel(aluno, null, null, excludeProperties: new[] { "Nome"});
        //    TryUpdateModel(aluno, includeProperties: new[] { "Id", "Email", "Idade", "DataInscricao", "Sexo"});

        //    if (ModelState.IsValid)
        //    {
        //        alunoBll.EditarAluno(aluno);
        //        return RedirectToAction("Index");
        //    }
        //    return View(aluno);

        //}

        //-- Utilizando Bind
        [HttpPost]
        [ActionName("Edit")]
        //public ActionResult Edit_Post([Bind(Exclude = "Nome")]Aluno aluno)
        public ActionResult Edit_Post([Bind(Include = "id, email, Idade, DataInscricao, Sexo")]Aluno aluno)
        {
            AlunoBLL alunoBll = new AlunoBLL();

            //-- Como não passo o nome no Bind, preciso preenche-lo para que não dê erro no Editar pois o nome é necessário
            aluno.Nome = alunoBll.getAlunos().Single(x => x.Id == aluno.Id).Nome;


            if (ModelState.IsValid)
            {
                alunoBll.EditarAluno(aluno);
                return RedirectToAction("Index");
            }
            return View(aluno);

        }

        //-- Delete usando GET - não usar
        //public ActionResult Delete(int id)
        //{
        //    AlunoBLL alunoBll = new AlunoBLL();
        //    alunoBll.DeletarAluno(id);
        //    return RedirectToAction("Index");
        //}

        [HttpPost]
        public ActionResult Delete(int id)
        {
            AlunoBLL alunoBll = new AlunoBLL();
            alunoBll.DeletarAluno(id);
            return RedirectToAction("index");
        }
        

        public ActionResult Details(int id)
        {
            AlunoBLL alunoBll = new AlunoBLL();
            Aluno aluno = alunoBll.getAlunos().Single(x => x.Id == id);

            return View(aluno);
        }   

        public ActionResult Procurar(string procurarPor, string criterio)
        {
            AlunoBLL alunoBll = new AlunoBLL();
            Aluno aluno = new Aluno();
            if (procurarPor == "Email")
            {
                 aluno = alunoBll.getAlunos().SingleOrDefault(x => x.Email == criterio || criterio == null);               
            }
            else
            {
                aluno = alunoBll.getAlunos().SingleOrDefault(x => x.Nome == criterio || criterio == null);
                // para retornar mais, uso getAlunos().Where(), mas devo receber numa List
            }

            if (aluno != null)
            {
                return View(aluno);

            }
            else
            {
                return RedirectToAction("NaoEncontrado");                
            }
        }

        public ActionResult NaoEncontrado()
        {
            return View();
        }

        //[HttpPost]
        //public ActionResult Delete(Aluno aluno)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        AlunoBLL alunoBll = new AlunoBLL();
        //        alunoBll.DeletarAluno(aluno.Id);
        //        return RedirectToAction("index");
        //    }

        //    return View(aluno);
        //}


        //[HttpPost]
        //public ActionResult Delete(Aluno aluno)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        AlunoBLL alunoBll = new AlunoBLL();
        //        alunoBll.DeletarAluno(aluno.Id);
        //        return RedirectToAction("Index");
        //    }
        //    return View(aluno);

        //}



    }
}