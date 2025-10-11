using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using univesp_pi2.Models;

namespace univesp_pi2.Controllers
{
    public class ProdutoController : Controller
    {
        private readonly string connectionString = "Server=localhost;Database=univesp;User Id=root;Password=suasenha;";

        public IActionResult Detalhes(int id)
        {
            Produto? produto = null;

            using (var conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string sql = "SELECT Id, Nome, Preco, Descricao, Detalhes, ImagemUrl FROM Produto WHERE Id = @id";
                using (var cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            produto = new Produto
                            {
                                Id = reader.GetInt32("Id"),
                                Nome = reader.GetString("Nome"),
                                Preco = reader.GetDecimal("Preco"),
                                Descricao = reader.GetString("Descricao"),
                                Detalhes = reader.GetString("Detalhes"),
                                ImagemUrl = reader.GetString("ImagemUrl")
                            };
                        }
                    }
                }
            }

            if (produto == null)
                return NotFound();

            return View(produto);
        }
    }
}
