namespace WebApi;
using Microsoft.AspNetCore.Mvc;
using Services;
using Domain;
[ApiController]
[Route("[controller]")]
public class QuoteController : ControllerBase
{
    private ToDoServices _quoteservices;
    public QuoteController()
    {
        _quoteservices = new ToDoServices();
    }
    [HttpGet("GetQuotes")]
    public async Task<List<Todo> GetQuotes()
    {
        return await _quoteservices.GetQuotes();
    }
    [HttpPost("AddQuote")]
    public async Task<string> AddQuote(Todo quote)
    {
        return await _quoteservices.AddQuote(quote);
    }
    [HttpPut("UpdateQuote")]
    public async Task<string> UpdateQuote(Todo quote)
    {
        return await _quoteservices.UpdateQuote(quote);
    }
    [HttpDelete("DeleteQuote")]
    public async Task<string> DeleteQuote(int id)
    {
        return await _quoteservices.DeleteQuote(id);
    }
    [HttpGet("GetAllQuotesByCategory")]
    public async Task<List<Todo>> GetAllQuotesByCategory(int id)
    {
        return await _quoteservices.GetAllQuotesByCategory(id);
    }
    [HttpGet("GetRandom")]
    public async Task<string> GetRandom(int id)
    {
        return await _quoteservices.GetRandom(id);
    }
}
