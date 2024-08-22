using System;
using System.Collections.Generic;
using System.Text;
using MySqlConnector;
using AppMulti.Models;
using System.Data;

namespace AppMulti.Controller
{
    public class MySQLCon
    {
        static string con = @"server=db4free.net;port=3306;database=aula2023;user id=camargo;password=abc321973;charset=utf8";

        public static List<Pessoa> ListarPessoas()
        {
            List<Pessoa> listapessoa = new List<Pessoa>();
            string sql = "SELECT * FROM pessoa";
            using (MySqlConnection conn = new MySqlConnection(con))
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                {
                    using (MySqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            Pessoa pessoa = new Pessoa()
                            {
                                id = dr.GetInt32(0),
                                nome = dr.GetString(1),
                                idade = dr.GetString(2)
                            };
                            listapessoa.Add(pessoa);
                        }
                    }
                }
                conn.Close();
                return listapessoa;
            }
        }

        public static void InserirPessoa(string nome, string idade)
        {
            string sql = "INSERT INTO pessoa(nome,idade) VALUES (@nome,@idade)";
            using (MySqlConnection conn = new MySqlConnection(con))
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.Add("@nome", MySqlDbType.VarChar).Value = nome;
                    cmd.Parameters.Add("@idade", MySqlDbType.VarChar).Value = idade;
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                }
                conn.Close();
            }
        }

        public static void AtualizarPessoa(Pessoa pessoa)
        {
            string sql = "UPDATE pessoa SET nome=@nome,idade=@idade WHERE id=@id";
            try
            {
                using (MySqlConnection conn = new MySqlConnection(con))
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.Add("@nome", MySqlDbType.VarChar).Value = pessoa.nome;
                        cmd.Parameters.Add("@idade", MySqlDbType.VarChar).Value = pessoa.idade;
                        cmd.Parameters.Add("@id", MySqlDbType.Int32).Value = pessoa.id;
                        cmd.CommandType = CommandType.Text;
                        cmd.ExecuteNonQuery();
                    }
                    conn.Close();
                }
            }
            catch (Exception ex)
            {

            }
        }

        public static void ExcluirPessoa(Pessoa pessoa)
        {
            string sql = "DELETE FROM pessoa WHERE id=@id";
            using (MySqlConnection conn = new MySqlConnection(con))
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.Add("@id", MySqlDbType.Int32).Value = pessoa.id;
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                }
                conn.Close();
            }
        }
    }
}
