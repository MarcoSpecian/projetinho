using projetinho.Models;
using projetinho.Repositorio;
namespace projeto1.Repositorio
{
    public class ProdutoRepositorio
    {
        private readonly string _connectionString;

        public ProdutoRepositorio(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public void AdicionarUsuario(Produto produto)
        {
            using (var db = new Conexao(_connectionString))
            {
                var cmd = db.MySqlCommand();
                cmd.CommandText = "INSERT INTO Produto (Id,Nome,Descricao,Preco) VALUES (@Id,@Nome,@Descricao,@Preco)";
                cmd.Parameters.AddWithValue("@Id", produto.Id);
                cmd.Parameters.AddWithValue("@Nome", produto.Nome);
                cmd.Parameters.AddWithValue("@Id", produto.Descricao);
                cmd.Parameters.AddWithValue("@Senha", produto.Preco);
                cmd.ExecuteNonQuery();

            }
        }
        public Usuario ObterUsuario(string email)
        {
            using (var db = new Conexao(_connectionString))
            {
                var cmd = db.MySqlCommand();
                cmd.CommandText = "SELECT * FROM Usuario WHERE Email = @Email";
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.ExecuteNonQuery();

                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Usuario
                        {
                            Id = reader.GetInt32("Id"),
                            Nome = reader.GetString("Nome"),
                            Email = reader.GetString("Email"),
                            Senha = reader.GetString("Senha"),

                        };

                    }

                }
                return null;
            }
        }
    }
}

