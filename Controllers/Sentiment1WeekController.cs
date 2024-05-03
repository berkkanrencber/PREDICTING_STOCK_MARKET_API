using System.Net.Http.Headers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PREDICTING_STOCK_MARKET_API.Models;

namespace PREDICTING_STOCK_MARKET_API.Controllers;


// localhost:8080/api/sentiment1week
[ApiController]
[Route("api/sentiment1week")]
public class Sentiment1WeekController:ControllerBase{

    private readonly StocksContext _context;

    public Sentiment1WeekController(StocksContext context)
    {
        _context = context;
    }

    // localhost:8080/api/sentiment1week => GET
    [HttpGet]
    public async Task<IActionResult> GetSentiment1Weeks(){
        
        var sentiment1week = await _context.Sentiment1Week.ToListAsync();
        return Ok(sentiment1week);
    }

    // localhost:8080/api/sentiment1week/1 => GET
    [Authorize]
    [HttpGet("{id}")]
    public async Task<IActionResult> GetSentiment1Week(int? id){
        
        if(id==null){
            return NotFound();
        }

        var s = await _context.Sentiment1Week.FirstOrDefaultAsync(i=>i.StockId==id);

        if(s==null){
            return NotFound();
        }

        return Ok(s);
    }

    [HttpPost]
    public async Task<IActionResult> AddSentiment1WeekData(Sentiment1Week entity){
        _context.Sentiment1Week.Add(entity);

        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetSentiment1Week),new {id=entity.StockId},entity);

    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateSentiment1Week(int id, Sentiment1Week entity){

        if(id != entity.StockId){
            return BadRequest();
        }

        var sentiment1Week = await _context.Sentiment1Week.FirstOrDefaultAsync(i=> i.StockId==id);

        if(sentiment1Week==null){
            return NotFound();
        }

        sentiment1Week.StockName=entity.StockName;
        sentiment1Week.StockGeneralSentiment=entity.StockGeneralSentiment;
        sentiment1Week.StockRetweetSentiment=entity.StockRetweetSentiment;
        sentiment1Week.StockReplySentiment=entity.StockReplySentiment;
        sentiment1Week.StockLikeSentiment=entity.StockLikeSentiment;
        sentiment1Week.StockResultSentiment=entity.StockResultSentiment;



        try{
            await _context.SaveChangesAsync();
        }catch(Exception){
            return NotFound();
        }

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteSentiment1Week(int? id){

        if(id == null){
            return NotFound();
        }

        var sentiment1Week= await _context.Sentiment1Week.FirstOrDefaultAsync(i=>i.StockId==id);

        if(sentiment1Week==null){
            return NotFound();
        }

        _context.Sentiment1Week.Remove(sentiment1Week);

        try{
            await _context.SaveChangesAsync();
        }catch(Exception){
            return NotFound();
        }

        return NoContent();
    }
}
