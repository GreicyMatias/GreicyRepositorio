﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient; //inserir bliblioteca

namespace BancoDeDados
{
    class Program_SQL
    {
        public static string Opcao = null;
        static void MenuPrincipal()
        {
            do
            {

                Opcao = null;
                Console.Clear();
                //Console.BackgroundColor = ConsoleColor.;
                Console.WriteLine();
                Console.WriteLine("░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░");
                Console.WriteLine("╔════════════════════════════════════════════════════════════════════════╗");
                Console.WriteLine("║                                  MENU                                  ║");
                Console.WriteLine("╠════════════════════════════════════════════════════════════════════════╣");
                Console.WriteLine("║                             1 - CADASTRO                               ║");
                Console.WriteLine("║                             2 - CONSULTA                               ║");
                Console.WriteLine("║                             3 - ALTERACAO                              ║");
                Console.WriteLine("║                             4 - REMOCAO                                ║");                
                Console.WriteLine("║                             5 - SAIR                                   ║");
                Console.WriteLine("╚════════════════════════════════════════════════════════════════════════╝");

                Opcao = Console.ReadLine();
                switch (Opcao)
                {
                    case "1":
                        MenuCadastro();
                        break;
                    case "2":
                        MenuConsulta();
                        break;
                    case "3":
                        //MenuAlteracao();
                        break;
                    case "4":
                        //MenuRemocao();
                        break;                                        
                    case "5":
                        Console.WriteLine("\nO programa está sendo encerrado. Aperte qualquer tecla para continuar!");
                        break;
                    default:
                        Console.WriteLine("\a\a\aVoce digitou uma opcao invalida! Aperte uma tecla para continuar.");
                        Console.ReadKey();
                        continue;
                }
            } while (Opcao != "5");
        }
        static void MenuCadastro()
        {
            do
            {
                Opcao = null;
                Console.Clear();
                Console.WriteLine("╔════════════════════════════════════════════════════════════════════════╗");
                Console.WriteLine("║                              MENU CADASTRO                             ║");
                Console.WriteLine("╠════════════════════════════════════════════════════════════════════════╣");
                Console.WriteLine("║                         1 - CADASTRO CLIENTE                           ║");
                Console.WriteLine("║                         2 - CADASTRO PRODUTO                           ║");
                Console.WriteLine("║                         3 - CADASTRO PEDIDO                            ║");
                Console.WriteLine("║                         4 - VOLTAR                                     ║");
                Console.WriteLine("╚════════════════════════════════════════════════════════════════════════╝");

                Opcao = Console.ReadLine();
                switch (Opcao)
                {
                    case "1":
                        //Chama o  metodo cadastro carro
                        CadastroCliente();
                        break;
                    case "2":
                        //Chamar metodo cadastro cliente
                        CadastroProduto();
                        break;
                    case "3":                        
                        CadastroPedido();
                        break;
                    case "4":
                        break;
                    default:
                        Console.WriteLine("\a\a\aVoce digitou uma opcao invalida! Tente novamente.");
                        Console.ReadKey();
                        continue;
                }
            } while (Opcao != "4");
        }
        static void MenuConsulta()
        {
            do
            {
                Console.Clear();
                Opcao = null;
                Console.WriteLine("╔════════════════════════════════════════════════════════════════════════╗");
                Console.WriteLine("║                              MENU CONSULTA                             ║");
                Console.WriteLine("╠════════════════════════════════════════════════════════════════════════╣");
                Console.WriteLine("║                         1 - CONSULTAR PRODUTO                          ║");
                Console.WriteLine("║                         2 - CONSULTAR CLIENTE                          ║");
                Console.WriteLine("║                         3 - CONSULTAR PEDIDO                           ║");                
                Console.WriteLine("║                         4 - VOLTAR                                     ║");
                Console.WriteLine("╚════════════════════════════════════════════════════════════════════════╝");


                Opcao = Console.ReadLine();

                switch (Opcao)
                {

                    case "1":
                        //Chama o  metodo CONSULTA carro
                        ConsultaProduto();
                        break;
                    case "2":
                        //Chamar metodo CONSULTA cliente
                        //ConsultaCliente();
                        break;                    
                    case "3":                        
                        ConsultaPedido();
                        break;
                    case "4":                        
                        break;
                    default:
                        Console.WriteLine("\a\a\aVoce digitou uma opcao invalida! Tente novamente.");
                        Console.ReadKey();
                        continue;
                }
            } while (Opcao != "4");
        }
        static void ConsultaCliente()
        {

        }
        static void ConsultaProduto()
        {
            string connectionString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=c:\users\greicy\documents\visual studio 2013\Projects\GreicyRepositorio\BancoDeDados\BandoDeDados\GreicyDB.mdf;Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(connectionString);            
            sqlConnection.Open();
            SqlCommand select = new SqlCommand(@"SELECT * FROM Produto", sqlConnection);
            SqlDataReader dataReader = select.ExecuteReader();

            while (dataReader.Read())
            {
                Console.WriteLine(dataReader["Nome"]);
            }
            sqlConnection.Close();
            Console.ReadKey();
        }
        static void ConsultaPedido()
        {

            string connectionString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=c:\users\greicy\documents\visual studio 2013\Projects\GreicyRepositorio\BancoDeDados\BandoDeDados\GreicyDB.mdf;Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();
            SqlCommand select = new SqlCommand(@"SELECT P.Nome, C.PrimeiroNome, PD.DataPedido, PD.Quantidade " +
                                               "FROM Pedido AS PD " +
                                               "INNER JOIN Cliente AS C ON PD.Cliente_Id = C.Id " +
                                               "INNER JOIN Produto AS P ON PD.Produto_Id = P.Id", sqlConnection);
            SqlDataReader dataReader = select.ExecuteReader();
            while (dataReader.Read())
            {
                Console.WriteLine("Data de Hoje:" + dataReader["DataPedido"]);
                Console.WriteLine("Quantidade:" + dataReader["Quantidade"]);
                Console.WriteLine("Produto:" + dataReader["Nome"]);
                Console.WriteLine("Cliente:" + dataReader["PrimeiroNome"]);
            }
            sqlConnection.Close();
            Console.ReadKey();
        }
        static void CadastroCliente()
        {
            string connectionString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=c:\users\greicy\documents\visual studio 2013\Projects\GreicyRepositorio\BancoDeDados\BandoDeDados\GreicyDB.mdf;Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(connectionString);            
            sqlConnection.Open();
            Console.WriteLine("Digite o primeiro nome do cliente: ");
            string nome = Console.ReadLine();
            Console.WriteLine("Digite o sobrenome do cliente: ");
            string sobrenome = Console.ReadLine();
            Console.WriteLine("Digite a cidade do cliente: ");
            string cidade = Console.ReadLine();
            Console.WriteLine("Digite o estado do cliente: ");
            string UF = Console.ReadLine();
            Console.WriteLine("Digite o CEP do cliente: ");
            string CEP = Console.ReadLine();
            Console.WriteLine("Digite o CPF do cliente: ");
            string CPF = Console.ReadLine();
            Console.WriteLine("Digite o telefone do cliente: ");
            string tel = Console.ReadLine();
            string sqlInsert = String.Format(" INSERT INTO Cliente (PrimeiroNome, Sobrenome, Cidade, Estado, CEP, CPF, Telefone) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}')", nome, sobrenome, cidade, UF, CEP, CPF, tel);
            SqlCommand command = new SqlCommand(sqlInsert, sqlConnection);
            try
            {
                int i = command.ExecuteNonQuery();
                if (i > 0)
                {
                    Console.WriteLine("Cliente cadastrado com sucesso!");
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
            }
            Console.ReadKey();
            sqlConnection.Close();            
        }
        static void CadastroProduto()
        {
            string connectionString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=c:\users\greicy\documents\visual studio 2013\Projects\GreicyRepositorio\BancoDeDados\BandoDeDados\GreicyDB.mdf;Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();
            Console.WriteLine("Digite o nome do produto: ");
            string nome = Console.ReadLine();
            Console.WriteLine("Digite a unidade do produto: ");
            string unidade = Console.ReadLine();
            Console.WriteLine("Digite o valor do produto: ");
            decimal valor = Convert.ToDecimal(Console.ReadLine());
            string sqlInsert = String.Format(" INSERT INTO Produto (Nome, Unidade, Valor) VALUES ('{0}', '{1}', '{2}')", nome, unidade, valor);
            SqlCommand command = new SqlCommand(sqlInsert, sqlConnection);
            try
            {
                int i = command.ExecuteNonQuery();
                if (i > 0)
                {
                    Console.WriteLine("Produto inserido com sucesso!");
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
            }
            sqlConnection.Close();
            Console.ReadKey();
        }
        static void CadastroPedido()
        {
            string connectionString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=c:\users\greicy\documents\visual studio 2013\Projects\GreicyRepositorio\BancoDeDados\BandoDeDados\GreicyDB.mdf;Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();
            var dataPedido = DateTime.Now;
            Console.WriteLine("Digite a quantidade de produtos: ");
            var quantidade = int.Parse(Console.ReadLine());
            int produtoId = 8; //fazer uma logica de busca
            int clienteId = 1; // fazer uma logica de busca
            string sql = String.Format(@"INSERT INTO Pedido (DataPedido, Quantidade, Produto_Id, Cliente_Id) VALUES ('{0}', {1}, {2}, {3})",dataPedido, quantidade, produtoId, clienteId);
            SqlCommand insert = new SqlCommand(sql, sqlConnection);
            try
            {
                int i = insert.ExecuteNonQuery();
                if (i > 0)
                {
                    Console.WriteLine("Pedido realizado com sucesso!");
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
            }
            sqlConnection.Close();
            Console.ReadKey();
        }
        static void Main1(string[] args)
        {
            //CONNECTION STRING
            string connectionString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=c:\users\greicy\documents\visual studio 2013\Projects\GreicyRepositorio\BancoDeDados\BandoDeDados\GreicyDB.mdf;Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            //ABRINDO CONEXÃO
            sqlConnection.Open();
            //REALIZAR COMANDOS
            //SqlCommand command = new SqlCommand("SELECT*FROM Produto ", sqlConnection);
            //SqlDataReader reader = command.ExecuteReader();           
            //while (reader.Read())
            //{
            //    Console.WriteLine(reader["Nome"]);
            //}
            //Console.WriteLine("Digite o Id do produto a ser editado: ");
            //int id = Convert.ToInt32(Console.ReadLine());
            //Console.WriteLine("Digite o nome do produto: ");
            //string nome = Console.ReadLine();
            //string sqlUpdate = String.Format("UPDATE Produto SET Nome = '{0}' WHERE Id = {1}", nome,id);
            //SqlCommand command = new SqlCommand(sqlUpdate, sqlConnection);
            //int i = command.ExecuteNonQuery();
            //try
            //{
            //    int i = command.ExecuteNonQuery();
            //    if(i>0)
            //    {          
            //          Console.WriteLine("Produto atualizado com sucesso!");
            //    }
            //}
            //catch(SqlException e){
            //    Console.WriteLine(e.ToString());
            //}
            //if (i > 0)
            //{
            //    Console.WriteLine("Produto atualizado com sucesso!");
            //}
            //else
            //{
            //    Console.WriteLine("FODEU!");
            //}
            //DELETA PRODUTO
            //Console.WriteLine("Digite o Id do produto a ser deletado: ");
            //int id = Convert.ToInt32(Console.ReadLine());            
            //string sqlDelete = String.Format("DELETE FROM Produto WHERE Id = {0}", id);
            //SqlCommand command = new SqlCommand(sqlDelete, sqlConnection);
            //try
            //{
            //    int i = command.ExecuteNonQuery();
            //    if (i > 0)
            //    {
            //        Console.WriteLine("Produto DELETADO com sucesso!");
            //    }
            //}
            //catch (SqlException e)
            //{
            //    Console.WriteLine(e.ToString());
            //}

            Console.WriteLine("Digite o nome do produto: ");
            string nome = Console.ReadLine();
            Console.WriteLine("Digite a unidade do produto: ");
            string unidade = Console.ReadLine();
            Console.WriteLine("Digite o valor do produto: ");
            decimal valor = Convert.ToDecimal(Console.ReadLine());
            string sqlInsert = String.Format(" INSERT INTO Produto (Nome, Unidade, Valor) VALUES ('{0}', '{1}', '{2}')", nome, unidade, valor);
            SqlCommand command = new SqlCommand(sqlInsert, sqlConnection);
            try
            {
                int i = command.ExecuteNonQuery();
                if (i > 0)
                {
                    Console.WriteLine("Produto inserido com sucesso!");
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
            }


            //FECHA CONEXÃO
            sqlConnection.Close();
            Console.ReadKey();
        }
        static void Main2(string[] args)
        {
            //CONNECTION STRING
            string connectionString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=c:\users\greicy\documents\visual studio 2013\Projects\GreicyRepositorio\BancoDeDados\BandoDeDados\GreicyDB.mdf;Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            //ABRINDO CONEXÃO
            sqlConnection.Open();
            //REALIZAR COMANDOS

            //ALTERA CLIENTE            
            //SqlCommand command = new SqlCommand("SELECT*FROM Cliente ", sqlConnection);
            //SqlDataReader reader = command.ExecuteReader();           
            //while (reader.Read())
            //{
            //    Console.WriteLine(reader["Primeiro Nome"]);
            //}
            //Console.WriteLine("Digite o Id do cliente a ser editado: ");
            //int id = Convert.ToInt32(Console.ReadLine());
            //Console.WriteLine("Digite o primeiro nome do cliente: ");
            //string nome = Console.ReadLine();
            //string sqlUpdate = String.Format("UPDATE Cliente SET Primeiro Nome = '{0}' WHERE Id = {1}", nome,id);
            //SqlCommand command = new SqlCommand(sqlUpdate, sqlConnection);
            //int i = command.ExecuteNonQuery();
            //try
            //{
            //    int i = command.ExecuteNonQuery();
            //    if(i>0)
            //    {          
            //          Console.WriteLine("Cliente atualizado com sucesso!");
            //    }
            //}
            //catch(SqlException e){
            //    Console.WriteLine(e.ToString());
            //}
          
            //-----------------------------------------------------------------------------------------------------------------
            //DELETA CLIENTE
            //Console.WriteLine("Digite o Id do Cliente a ser deletado: ");
            //int id = Convert.ToInt32(Console.ReadLine());            
            //string sqlDelete = String.Format("DELETE FROM Cliente WHERE Id = {0}", id);
            //SqlCommand command = new SqlCommand(sqlDelete, sqlConnection);
            //try
            //{
            //    int i = command.ExecuteNonQuery();
            //    if (i > 0)
            //    {
            //        Console.WriteLine("Cliente DELETADO com sucesso!");
            //    }
            //}
            //catch (SqlException e)
            //{
            //    Console.WriteLine(e.ToString());
            //}
            //----------------------------------------------------------------------------------------------------------------------
            //CADASTRA CLIENTE
            Console.WriteLine("Digite o primeiro nome do cliente: ");
            string nome = Console.ReadLine();
            Console.WriteLine("Digite o sobrenome do cliente: ");
            string sobrenome = Console.ReadLine();
            Console.WriteLine("Digite a cidade do cliente: ");
            string cidade = Console.ReadLine();
            Console.WriteLine("Digite o estado do cliente: ");
            string UF = Console.ReadLine();
            Console.WriteLine("Digite o CEP do cliente: ");
            string CEP = Console.ReadLine();
            Console.WriteLine("Digite o CPF do cliente: ");
            string CPF = Console.ReadLine();
            Console.WriteLine("Digite o telefone do cliente: ");
            string tel = Console.ReadLine();
            string sqlInsert = String.Format(" INSERT INTO Cliente (PrimeiroNome, Sobrenome, Cidade, Estado, CEP, CPF, Telefone) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}')", nome, sobrenome, cidade, UF, CEP, CPF, tel);
            SqlCommand command = new SqlCommand(sqlInsert, sqlConnection);
            try
            {
                int i = command.ExecuteNonQuery();
                if (i > 0)
                {
                    Console.WriteLine("Cliente cadastrado com sucesso!");
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
            }


            //FECHA CONEXÃO
            sqlConnection.Close();
            Console.ReadKey();
        }
        static void Main(string[] args)
        {
            MenuPrincipal();
        }
    }
}

