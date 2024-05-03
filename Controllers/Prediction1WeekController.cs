using System.Net.Http.Headers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PREDICTING_STOCK_MARKET_API.Models;

namespace PREDICTING_STOCK_MARKET_API.Controllers;


// localhost:8080/api/prediction1week
[ApiController]
[Route("api/prediction1week")]
public class Prediction1WeekController:ControllerBase{

    private readonly StocksContext _context;

    public Prediction1WeekController(StocksContext context)
    {
        _context = context;
    }

    // localhost:8080/api/prediction1week => GET
    [HttpGet]
    public async Task<IActionResult> GetPrediction1Weeks(){
        
        var prediction1week = await _context.Prediction1Week.ToListAsync();
        return Ok(prediction1week);
    }

    // localhost:8080/api/prediction1week/1 => GET
    [Authorize]
    [HttpGet("{id}")]
    public async Task<IActionResult> GetPrediction1Week(int? id){
        
        if(id==null){
            return NotFound();
        }

        var s = await _context.Prediction1Week.FirstOrDefaultAsync(i=>i.StockId==id);

        if(s==null){
            return NotFound();
        }

        return Ok(s);
    }

    [HttpPost]
    public async Task<IActionResult> AddPrediction1WeekData(Prediction1Week entity){
        _context.Prediction1Week.Add(entity);

        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetPrediction1Week),new {id=entity.StockId},entity);

    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdatePrediction1Week(int id, Prediction1Week entity){

        if(id != entity.StockId){
            return BadRequest();
        }

        var prediction1Week = await _context.Prediction1Week.FirstOrDefaultAsync(i=> i.StockId==id);

        if(prediction1Week==null){
            return NotFound();
        }

        prediction1Week.StockNameAndPrice=entity.StockNameAndPrice;
        prediction1Week.RF=entity.RF;
        prediction1Week.LSTM=entity.LSTM;
        prediction1Week.Prophet=entity.Prophet;
        prediction1Week.StockResultSentiment=entity.StockResultSentiment;
        prediction1Week.SelectPrice=entity.SelectPrice;



        try{
            await _context.SaveChangesAsync();
        }catch(Exception){
            return NotFound();
        }

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletePrediction1Week(int? id){

        if(id == null){
            return NotFound();
        }

        var prediction1Week= await _context.Prediction1Week.FirstOrDefaultAsync(i=>i.StockId==id);

        if(prediction1Week==null){
            return NotFound();
        }

        _context.Prediction1Week.Remove(prediction1Week);

        try{
            await _context.SaveChangesAsync();
        }catch(Exception){
            return NotFound();
        }

        return NoContent();
    }
}
