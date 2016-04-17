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
                        aluno.Foto = rdr["Foto"].ToString();
                        aluno.Texto = rdr["Texto"].ToString();
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

        public void IncluirAluno(Aluno aluno)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ConSqlServer"].ConnectionString;

            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("IncluirAlunos", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlParameter paramNome = new SqlParameter();
                    paramNome.ParameterName = "@Nome";
                    paramNome.Value = aluno.Nome;
                    cmd.Parameters.Add(paramNome);

                    SqlParameter paramEmail = new SqlParameter();
                    paramEmail.ParameterName = "@Email";
                    paramEmail.Value = aluno.Email;
                    cmd.Parameters.Add(paramEmail);

                    SqlParameter paramIdade = new SqlParameter();
                    paramIdade.ParameterName = "@Idade";
                    paramIdade.Value = aluno.Idade;
                    cmd.Parameters.Add(paramIdade);

                    SqlParameter paramDataInscricao = new SqlParameter();
                    paramDataInscricao.ParameterName = "@DataInscricao";
                    paramDataInscricao.Value = aluno.DataInscricao;
                    cmd.Parameters.Add(paramDataInscricao);

                    SqlParameter paramSexo = new SqlParameter();
                    paramSexo.ParameterName = "@Sexo";
                    paramSexo.Value = aluno.Sexo;
                    cmd.Parameters.Add(paramSexo);

                    SqlParameter paramFoto = new SqlParameter();
                    paramFoto.ParameterName = "@Foto";
                    paramFoto.Value = aluno.Foto;
                    cmd.Parameters.Add(paramFoto);

                    SqlParameter paramTexto= new SqlParameter();
                    paramTexto.ParameterName = "@Texto";
                    paramTexto.Value = aluno.Texto;
                    cmd.Parameters.Add(paramTexto);

                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch
            {
                throw;
            }

        }


        public void EditarAluno(Aluno aluno)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ConSqlServer"].ConnectionString;

            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("AtualizarAluno", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlParameter paramId = new SqlParameter();
                    paramId.ParameterName = "@Id";
                    paramId.Value = aluno.Id;
                    cmd.Parameters.Add(paramId);

                    SqlParameter paramNome = new SqlParameter();
                    paramNome.ParameterName = "@Nome";
                    paramNome.Value = aluno.Nome;
                    cmd.Parameters.Add(paramNome);

                    SqlParameter paramEmail = new SqlParameter();
                    paramEmail.ParameterName = "@Email";
                    paramEmail.Value = aluno.Email;
                    cmd.Parameters.Add(paramEmail);

                    SqlParameter paramIdade = new SqlParameter();
                    paramIdade.ParameterName = "@Idade";
                    paramIdade.Value = aluno.Idade;
                    cmd.Parameters.Add(paramIdade);

                    SqlParameter paramDataInscricao = new SqlParameter();
                    paramDataInscricao.ParameterName = "@DataInscricao";
                    paramDataInscricao.Value = aluno.DataInscricao;
                    cmd.Parameters.Add(paramDataInscricao);

                    SqlParameter paramSexo = new SqlParameter();
                    paramSexo.ParameterName = "@Sexo";
                    paramSexo.Value = aluno.Sexo;
                    cmd.Parameters.Add(paramSexo);

                    SqlParameter paramFoto = new SqlParameter();
                    paramFoto.ParameterName = "@Foto";
                    paramFoto.Value = aluno.Foto;
                    cmd.Parameters.Add(paramFoto);

                    SqlParameter paramTexto = new SqlParameter();
                    paramTexto.ParameterName = "@Texto";
                    paramTexto.Value = aluno.Texto;
                    cmd.Parameters.Add(paramTexto);

                    con.Open();
                    cmd.ExecuteNonQuery();

                }
            }
            catch
            {
                throw;
            }
        }

        public void DeletarAluno(int id)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ConSqlServer"].ConnectionString;

            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("DeletarAluno", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlParameter paramId = new SqlParameter();
                    paramId.ParameterName = "@Id";
                    paramId.Value = id;
                    cmd.Parameters.Add(paramId);

                    con.Open();
                    cmd.ExecuteNonQuery();                
                }
            }
            catch
            {
                throw;
            }
        }

        public void UpdateAluno(int id, string nome)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ConSqlServer"].ConnectionString;
            
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand(String.Format("Update Alunos set Nome = '{1}' where Id = {0}",id,nome), con);
                    cmd.CommandType = CommandType.Text;
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception)
            {
                throw;
            }                          
        }

        public IEnumerable<Aluno> getAlunos_Select()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ConSqlServer"].ConnectionString;

            List<Aluno> alunos = new List<Aluno>();

            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("Select * from Alunos Where 1=1", con);
                    cmd.CommandType = CommandType.Text;
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
                        aluno.Foto = rdr["Foto"].ToString();
                        aluno.Texto = rdr["Texto"].ToString();
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


        //SqlDataReader rdr = cmd.ExecuteReader();
        //            while (rdr.Read())
        //            {
        //                Aluno aluno = new Aluno();
        //aluno.Id = Convert.ToInt32(rdr["Id"]);



        public IEnumerable<Aluno> teste()
        {
            List<Aluno> alunos = new List<Aluno>();

            string connectionString = ConfigurationManager.ConnectionStrings["ConSqlServer"].ConnectionString;

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("Select * from Alunos", con);
                cmd.CommandType = CommandType.Text;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    Aluno aluno = new Aluno();                    
                    aluno.Id = Convert.ToInt32(rdr["id"]);
                    aluno.Nome = rdr["nome"].ToString();
                    aluno.Email = rdr["email"].ToString();
                    aluno.Idade = Convert.ToInt32(rdr["idade"]);
                    aluno.Sexo = rdr["sexo"].ToString();
                    aluno.Foto = rdr["foto"].ToString();
                    aluno.Texto = rdr["texto"].ToString();
                    alunos.Add(aluno);
                }
            }

            return alunos;
        }
       

        public void AtualizarTeste(int id, string nome)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ConSqlServer"].ConnectionString;

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(String.Format("Update Alunos set Nome = '{1}' Where id = {0} ", id, nome), con);
                cmd.CommandType = CommandType.Text;
                con.Open();
                cmd.ExecuteNonQuery();
                
            }
        }

    }
}
