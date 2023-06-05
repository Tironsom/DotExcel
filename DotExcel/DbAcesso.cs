using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotExcel
{
    public class DbAcesso
    {
        private Conexao Conexao;
        public SqlConnection connection;
        public void Connect()
        {
            Conexao = new Conexao();
            connection = Conexao.conectar();
        }
        public void Disconnect()
        {
            Conexao.desconectar();
        }


            public void SetPessoa(List<Pessoa> pessoaLista)
            {
                Connect();
                foreach (var pessoa in pessoaLista)
                {
                    using (SqlCommand command = new SqlCommand("proPessoas", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.Parameters.Add("@Nome", SqlDbType.VarChar, 255).Value = pessoa.nome;
                        //command.Parameters.Add("@id", SqlDbType.VarChar, 11).Value = pessoa.id;
                        command.Parameters.Add("@Email", SqlDbType.VarChar, 255).Value = pessoa.email;
                        command.ExecuteNonQuery();
                    Console.WriteLine("Cadastro completo");
                    }
                }
            }
        
             public List<Pessoa> getPessoa()
             {
 
                Connect();
                Pessoa pessoa;
                List<Pessoa> pessoaLista = new  List<Pessoa>();
                try
                {
                    Console.WriteLine("Carregando");
                    Console.WriteLine(".");
                    Console.WriteLine(".");
                    using (SqlCommand command = new SqlCommand("proGetPessoas", connection))
                        {
                            using (SqlDataReader reader = command.ExecuteReader())
                            {
                                Console.WriteLine(".");
                                while (reader.Read())
                                {
                                    pessoa = new Pessoa();
                                    pessoa.id = int.Parse(reader["id"].ToString()); ;
                                    pessoa.nome = reader["nome"].ToString();
                                    pessoa.email = reader["email"].ToString();

                                    pessoaLista.Add(pessoa);
                                }

                            }

                    }
                }
                catch(Exception e) 
                {
                    Console.WriteLine("Ocorreu um problema na consulta");
                }

               return pessoaLista;
             }
            public Pessoa GetDetalhado(int ID)
            {
            Connect();
            Pessoa pessoa = null;
            Pessoa PessBusc = null;

            using (SqlCommand command = new SqlCommand())
            {
                    command.Connection = connection;
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "proGetOnePessoas";
                    command.Parameters.AddWithValue("@id", ID);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            pessoa = new Pessoa();
                            pessoa.id = Convert.ToInt32(reader["id"]);
                            if(pessoa.id == ID)
                            {
                                PessBusc = new Pessoa();
                                PessBusc.id = Convert.ToInt32(reader["id"]);
                                PessBusc.nome = reader["nome"].ToString();
                                PessBusc.email = reader["email"].ToString();
                                
                            }
                        }
                    }
                }

                if (PessBusc != null)
                {
                    Console.WriteLine("id: " + PessBusc.id);
                    Console.WriteLine("nome: " + PessBusc.nome);
                    Console.WriteLine("email: " + PessBusc.email);
                    
                }
                else
                {
                    Console.WriteLine("Nenhuma pessoa encontrada com o ID selecionado.");
                }

                Disconnect();
                //Resolvido
                return  PessBusc;
            }

            public void Update(Pessoa p)
            {
                Connect();
                using (SqlCommand command = new SqlCommand("progetUpdate", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@ID", p.id);
                    command.Parameters.AddWithValue("@Nome", p.nome);
                    command.Parameters.AddWithValue("@Email", p.email);

                    command.ExecuteNonQuery();
                }
            }
    }

}

