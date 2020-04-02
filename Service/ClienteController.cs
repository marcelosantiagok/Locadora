using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;

namespace Service
{
    public class ClienteController
    {
        public List<Cliente> Listar()
        {
            string strConexao = "SERVER=localhost; DataBase=locadora; UID=root; pwd=1234";

            using (MySqlConnection conn = new MySqlConnection(strConexao))
            {
                conn.Open();

                using (MySqlCommand cmd = new MySqlCommand())
                {
                    string query = "SELECT IDCLIENTE, NOME, CPF, EMAIL FROM cliente";

                    cmd.Connection = conn;
                    cmd.CommandText = query;

                    using (MySqlDataAdapter da = new MySqlDataAdapter())
                    {
                        da.SelectCommand = cmd;

                        DataSet ds = new DataSet();
                        da.Fill(ds, "Cliente");


                        List<Cliente> lstRetorno = ds.Tables["Cliente"].AsEnumerable().Select(x => new Cliente
                        {
                            IdCliente = x.Field<int>("IdCliente"),
                            Nome = x.Field<string>("Nome"),
                            Cpf = x.Field<string>("Cpf"),
                            Email = x.Field<string>("Email")
                        }).ToList();


                        return lstRetorno;
                    }
                }
            }
        }

        public Cliente Buscar(int id)
        {

            string strConexao = "SERVER=localhost; DataBase=locadora; UID=root; pwd=1234";


            using (MySqlConnection conn = new MySqlConnection(strConexao))
            {

                conn.Open();


                using (MySqlCommand cmd = new MySqlCommand())
                {

                    string query = $"SELECT IDCliente, NOME, CPF,EMAIL FROM cliente WHERE IdCliente = {id}";


                    cmd.Connection = conn;
                    cmd.CommandText = query;


                    MySqlDataReader reader = cmd.ExecuteReader();


                    Cliente retorno = new Cliente();


                    while (reader.Read())
                    {

                        retorno.IdCliente = (int)reader["IdCliente"];
                        retorno.Nome = (string)reader["Nome"];
                        retorno.Cpf = (string)reader["Cpf"];
                        retorno.Email = (string)reader["Email"];
                    }

                    return retorno;
                }
            }
        }

        public void Inserir(Cliente registro)
        {

            string strConexao = "SERVER=localhost; DataBase=locadora; UID=root; pwd=1234";


            using (MySqlConnection conn = new MySqlConnection(strConexao))
            {

                conn.Open();


                using (MySqlCommand cmd = new MySqlCommand())
                {

                    string query = $"INSERT INTO Cliente (Nome, Cpf, Email) VALUES ('{registro.Nome}', '{registro.Cpf}', '{registro.Email}')";


                    cmd.Connection = conn;
                    cmd.CommandText = query;


                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Atualizar(Cliente registro)
        {

            string strConexao = "SERVER=localhost; DataBase=locadora; UID=root; pwd=1234";


            using (MySqlConnection conn = new MySqlConnection(strConexao))
            {

                conn.Open();


                using (MySqlCommand cmd = new MySqlCommand())
                {

                    string query = $@"UPDATE Cliente SET
                                    Nome = '{registro.Nome}',
                                    Cpf= '{registro.Cpf}',
                                    Email = '{registro.Email}'
                                    WHERE IDCLIENTE = {registro.IdCliente}";


                    cmd.Connection = conn;
                    cmd.CommandText = query;


                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Excluir(int id)
        {
            
            string strConexao = "SERVER=localhost; DataBase=locadora; UID=root; pwd=1234";

            
            using (MySqlConnection conn = new MySqlConnection(strConexao))
            {
                
                conn.Open();

                
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    
                    string query = $"DELETE FROM Cliente WHERE IdCliente = {id}";

                    
                    cmd.Connection = conn;
                    cmd.CommandText = query;

                    
                    cmd.ExecuteNonQuery();
                }
            }
        }


    }








}

