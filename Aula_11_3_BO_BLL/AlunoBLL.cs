using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Aula_11_3_BO_BLL
{
    public class AlunoBLL
    {
        public IEnumerable<Aluno> getAlunos()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ConSqlServer"].ConnectionString;

            List<Aluno> alunos = new List<Aluno>();

            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("GetAlunos", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        Aluno aluno = new Aluno();
                        aluno.Id = Convert.ToInt32(rdr["Id"]);
                        aluno.Nome = rdr["Nome"].ToString();
                        aluno.Email = rdr["Email"].ToString();
                        aluno.Idade = Convert.ToInt32(rdr["Idade"]);
                        aluno.DataInscricao = Convert.ToDateTime(rdr["DataInscricao"]);
                        aluno.Sexo = rdr["Sexo"].ToString();
                        alunos.Add(aluno);

                    }

                }
                return alunos;
            }
            catch
            {
                throw;
            }
        }
    }
}
