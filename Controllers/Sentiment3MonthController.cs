using System.Net.Http.Headers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PREDICTING_STOCK_MARKET_API.Models;

namespace PREDICTING_STOCK_MARKET_API.Controllers;


// localhost:8080/api/sentiment3month
[ApiController]
[Route("api/sentiment3month")]
public class Sentiment3MonthController:ControllerBase{

    private readonly StocksContext _context;

    public Sentiment3MonthController(StocksContext context)
    {
        _context = context;
    }

    // localhost:8080/api/sentiment3month => GET
    [HttpGet]
    public async Task<IActionResult> GetSentiment3Months(){
        
        var sentiment3month = await _context.Sentiment3Month.ToListAsync();
        return Ok(sentiment3month);
    }

    // localhost:8080/api/sentiment3month/1 => GET
    [Authorize]
    [HttpGet("{id}")]
    public async Task<IActionResult> GetSentiment3Month(int? id){
        
        if(id==null){
            return NotFound();
        }

        var s = await _context.Sentiment3Month.FirstOrDefaultAsync(i=>i.StockId==id);

        if(s==null){
            return NotFound();
        }

        return Ok(s);
    }

    [HttpPost]
    public async Task<IActionResult> AddSentiment3MonthData(Sentiment3Month entity){
        _context.Sentiment3Month.Add(entity);

        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetSentiment3Month),new {id=entity.StockId},entity);

    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateSentiment3Month(int id, Sentiment3Month entity){

        if(id != entity.StockId){
            return BadRequest();
        }

        var sentiment3Month = await _context.Sentiment3Month.FirstOrDefaultAsync(i=> i.StockId==id);

        if(sentiment3Month==null){
            return NotFound();
        }

        sentiment3Month.StockName=entity.StockName;
        sentiment3Month.StockGeneralSentiment=entity.StockGeneralSentiment;
        sentiment3Month.StockRetweetSentiment=entity.StockRetweetSentiment;
        sentiment3Month.StockReplySentiment=entity.StockReplySentiment;
        sentiment3Month.StockLikeSentiment=entity.StockLikeSentiment;
        sentiment3Month.StockResultSentiment=entity.StockResultSentiment;



        try{
            await _context.SaveChangesAsync();
        }catch(Exception){
            return NotFound();
        }

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteSentiment3Month(int? id){

        if(id == null){
            return NotFound();
        }

        var sentiment3Month= await _context.Sentiment3Month.FirstOrDefaultAsync(i=>i.StockId==id);

        if(sentiment3Month==null){
            return NotFound();
        }

        _context.Sentiment3Month.Remove(sentiment3Month);

        try{
            await _context.SaveChangesAsync();
        }catch(Exception){
            return NotFound();
        }

        return NoContent();
    }
}
