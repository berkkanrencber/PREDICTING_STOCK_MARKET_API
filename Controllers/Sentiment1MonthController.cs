using System.Net.Http.Headers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PREDICTING_STOCK_MARKET_API.Models;

namespace PREDICTING_STOCK_MARKET_API.Controllers;


// localhost:8080/api/sentiment1month
[ApiController]
[Route("api/sentiment1month")]
public class Sentiment1MonthController:ControllerBase{

    private readonly StocksContext _context;

    public Sentiment1MonthController(StocksContext context)
    {
        _context = context;
    }

    // localhost:8080/api/sentiment1month => GET
    [HttpGet]
    public async Task<IActionResult> GetSentiment1Months(){
        
        var sentiment1month = await _context.Sentiment1Month.ToListAsync();
        return Ok(sentiment1month);
    }

    // localhost:8080/api/sentiment1month/1 => GET
    [Authorize]
    [HttpGet("{id}")]
    public async Task<IActionResult> GetSentiment1Month(int? id){
        
        if(id==null){
            return NotFound();
        }

        var s = await _context.Sentiment1Month.FirstOrDefaultAsync(i=>i.StockId==id);

        if(s==null){
            return NotFound();
        }

        return Ok(s);
    }

    [HttpPost]
    public async Task<IActionResult> AddSentiment1MonthData(Sentiment1Month entity){
        _context.Sentiment1Month.Add(entity);

        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetSentiment1Month),new {id=entity.StockId},entity);

    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateSentiment1Month(int id, Sentiment1Month entity){

        if(id != entity.StockId){
            return BadRequest();
        }

        var sentiment1Month = await _context.Sentiment1Month.FirstOrDefaultAsync(i=> i.StockId==id);

        if(sentiment1Month==null){
            return NotFound();
        }

        sentiment1Month.StockName=entity.StockName;
        sentiment1Month.StockGeneralSentiment=entity.StockGeneralSentiment;
        sentiment1Month.StockRetweetSentiment=entity.StockRetweetSentiment;
        sentiment1Month.StockReplySentiment=entity.StockReplySentiment;
        sentiment1Month.StockLikeSentiment=entity.StockLikeSentiment;
        sentiment1Month.StockResultSentiment=entity.StockResultSentiment;



        try{
            await _context.SaveChangesAsync();
        }catch(Exception){
            return NotFound();
        }

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteSentiment1Month(int? id){

        if(id == null){
            return NotFound();
        }

        var sentiment1Month= await _context.Sentiment1Month.FirstOrDefaultAsync(i=>i.StockId==id);

        if(sentiment1Month==null){
            return NotFound();
        }

        _context.Sentiment1Month.Remove(sentiment1Month);

        try{
            await _context.SaveChangesAsync();
        }catch(Exception){
            return NotFound();
        }

        return NoContent();
    }
}
