using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aula_11_3_BO_BLL;

namespace Teste_ConsoleA
{
    public class Teste
    {
        public void testeDAL()
        {
            AlunoBLL alunoBll = new AlunoBLL();

            alunoBll.UpdateAluno(7, "Claudete");

            IEnumerable<Aluno> alunosIE = alunoBll.teste();            

            foreach (var alun in alunosIE)
            {
                Console.WriteLine("Nome {0}", alun.Nome);
            }

            alunoBll.UpdateAluno(7,"Joooooao");

            Console.WriteLine("\n");


            alunosIE = alunoBll.teste();
            foreach (var alun in alunosIE)
            {
                Console.WriteLine("Nome {0}", alun.Nome);
            }


            Console.ReadKey();
        }

    }
}
