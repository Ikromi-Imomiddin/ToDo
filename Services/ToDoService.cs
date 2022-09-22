using Dapper;
using Npgsql;
using Domain;
namespace Services;
public class ToDoServices
{
    private string _connectionString;
    public ToDoServices()
    {
        _connectionString = "Server=127.0.0.1;Port=5432;Database=TODO;User Id=postgres;Password=Ikromi8008;";
    }

    public async Task<List<ToDoServices>> GetQuotes()
    {
        using (NpgsqlConnection connection = new NpgsqlConnection(_connectionString))
        {
            var sql = "select * from Quote ;";
            var result = await connection.QueryAsync<ToDoServices>(sql);
            return result.ToList();
        }
    }

    public async Task<string> AddQuote(Todo quote)
    {

        using (NpgsqlConnection connection = new NpgsqlConnection(_connectionString))
            try

            {
                string? sql = $"Insert into Todo (Author,Quotetext,CategoryId) VAlUES ('{quote.Author}','{quote.Quotetext}',{quote.CategoryId})";

                {
                    var result = await connection.ExecuteAsync(sql);
                    return "Seccess";
                }
            }
            catch (Exception ex)

            {
                return $"Vary bad{ex.Message}";
            }

    }
    public async Task<string> DeleteQuote(int id)
    {

        using (NpgsqlConnection connection = new NpgsqlConnection(_connectionString))
        {
            string sql = $"delete from Quote where Id = '{id}';";
            try
            {

                var result = await connection.ExecuteAsync(sql);
                return "Seccess";
            }

            catch (Exception ex)
            {
                return $"Vary bad{ex.Message}";

            }
        }
    }
    public async Task<string> UpdateQuote(Quote quote)
    {

        using (NpgsqlConnection connection = new NpgsqlConnection(_connectionString))
        {
            string sql = $"UPDATE Quote SET Author = '{quote.Author}', CategoryId = '{quote.CategoryId}' WHERE Id = {quote.Id};";
            try
            {
                var result = await connection.ExecuteAsync(sql);
                return $"Seccess";
            }

            catch (Exception ex)
            {
                return $"Vary bad{ex.Message}";

            }
        }
    }
    public async Task<List<Todo>> GetAllQuotesByCategory(int id)
    {
        using (NpgsqlConnection connection = new NpgsqlConnection(_connectionString))

        {
            string sql = ($"select * from Quote where CategoryId = {id} ;");
            try
            {

                var result = await connection.QueryAsync<Quote>(sql);
                return result.ToList();
            }

            catch (Exception ex)
            {
                return  null;
            }
        }
    }

    public async Task<string> GetRandom(int id)
    {
        using (NpgsqlConnection connection = new NpgsqlConnection(_connectionString))
        {
            string sql = ($"select * from Quote order by random() Limit 1 ;");
            try
            {

                var result = await connection.ExecuteAsync(sql);
                return "Seccess";
            }
            catch (Exception ex)
            {
                return $"Vary bad{ex.Message}";
            }

        }
    }
}

