
using Npgsql;

namespace ProjetoSgbdSimples
{
        // Projeto simples para revisão basica.
    class Program
    {

        public static void Main(string[] args)
        {
            // Configuração da string de conexão com o banco de dados PostgreSQL
            string connectionString = "Host=localhost;Port=5432;Database=allog_clientes;Username=postgres;Password=123456";

            // Criação da conexão com o banco de dados usando a string de conexão
            using var connection = new NpgsqlConnection(connectionString);
            connection.Open();

            // Exibe uma mensagem indicando que a conexão foi estabelecida com sucesso
            Console.WriteLine("Conexão bem-sucedida ao banco de dados PostgreSQL!");

            // Consulta SELECT para retornar dados do banco de dados
            string query = "SELECT nome, endereco, telefone, email FROM clientes";

            // Criação de um comando para executar a consulta SQL usando a conexão estabelecida
            using var command = new NpgsqlCommand(query, connection);

            // Execução da consulta usando um leitor de dados
            using var reader = command.ExecuteReader();

           
            Console.WriteLine("Listagem de Usuários:\n");

            // Loop para ler os registros retornados pela consulta e exibi-los no console
            while (reader.Read())
            {
                // Obtém os valores das colunas "nome", "endereco", "telefone" e "email" para o registro atual
                string nome = reader.GetString(0);
                string endereco = reader.GetString(1);
                string telefone = reader.GetString(2);
                string email = reader.GetString(3);

                // Exibe as informações do usuário no console
                Console.WriteLine($"Nome: {nome}, Endereço: {endereco}, Telefone: {telefone}, Email: {email}");
            }

            // Fecha a conexão com o banco de dados
            connection.Close();
        }

    }
}