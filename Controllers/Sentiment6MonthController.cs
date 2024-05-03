using System.Net.Http.Headers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PREDICTING_STOCK_MARKET_API.Models;

namespace PREDICTING_STOCK_MARKET_API.Controllers;


// localhost:8080/api/sentiment6month
[ApiController]
[Route("api/sentiment6month")]
public class Sentiment6MonthController:ControllerBase{

    private readonly StocksContext _context;

    public Sentiment6MonthController(StocksContext context)
    {
        _context = context;
    }

    // localhost:8080/api/sentiment6month => GET
    [HttpGet]
    public async Task<IActionResult> GetSentiment6Months(){
        
        var sentiment6month = await _context.Sentiment6Month.ToListAsync();
        return Ok(sentiment6month);
    }

    // localhost:8080/api/sentiment6month/1 => GET
    [Authorize]
    [HttpGet("{id}")]
    public async Task<IActionResult> GetSentiment6Month(int? id){
        
        if(id==null){
            return NotFound();
        }

        var s = await _context.Sentiment6Month.FirstOrDefaultAsync(i=>i.StockId==id);

        if(s==null){
            return NotFound();
        }

        return Ok(s);
    }

    [HttpPost]
    public async Task<IActionResult> AddSentiment6MonthData(Sentiment6Month entity){
        _context.Sentiment6Month.Add(entity);

        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetSentiment6Month),new {id=entity.StockId},entity);

    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateSentiment6Month(int id, Sentiment6Month entity){

        if(id != entity.StockId){
            return BadRequest();
        }

        var sentiment6Month = await _context.Sentiment6Month.FirstOrDefaultAsync(i=> i.StockId==id);

        if(sentiment6Month==null){
            return NotFound();
        }

        sentiment6Month.StockName=entity.StockName;
        sentiment6Month.StockGeneralSentiment=entity.StockGeneralSentiment;
        sentiment6Month.StockRetweetSentiment=entity.StockRetweetSentiment;
        sentiment6Month.StockReplySentiment=entity.StockReplySentiment;
        sentiment6Month.StockLikeSentiment=entity.StockLikeSentiment;
        sentiment6Month.StockResultSentiment=entity.StockResultSentiment;



        try{
            await _context.SaveChangesAsync();
        }catch(Exception){
            return NotFound();
        }

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteSentiment6Month(int? id){

        if(id == null){
            return NotFound();
        }

        var sentiment6Month= await _context.Sentiment6Month.FirstOrDefaultAsync(i=>i.StockId==id);

        if(sentiment6Month==null){
            return NotFound();
        }

        _context.Sentiment6Month.Remove(sentiment6Month);

        try{
            await _context.SaveChangesAsync();
        }catch(Exception){
            return NotFound();
        }

        return NoContent();
    }
}
