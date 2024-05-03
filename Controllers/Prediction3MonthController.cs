using System.Net.Http.Headers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PREDICTING_STOCK_MARKET_API.Models;

namespace PREDICTING_STOCK_MARKET_API.Controllers;


// localhost:8080/api/prediction3month
[ApiController]
[Route("api/prediction3month")]
public class Prediction3MonthController:ControllerBase{

    private readonly StocksContext _context;

    public Prediction3MonthController(StocksContext context)
    {
        _context = context;
    }

    // localhost:8080/api/prediction3month => GET
    [HttpGet]
    public async Task<IActionResult> GetPrediction3Months(){
        
        var prediction3month = await _context.Prediction3Month.ToListAsync();
        return Ok(prediction3month);
    }

    // localhost:8080/api/prediction3month/1 => GET
    [Authorize]
    [HttpGet("{id}")]
    public async Task<IActionResult> GetPrediction3Month(int? id){
        
        if(id==null){
            return NotFound();
        }

        var s = await _context.Prediction3Month.FirstOrDefaultAsync(i=>i.StockId==id);

        if(s==null){
            return NotFound();
        }

        return Ok(s);
    }

    [HttpPost]
    public async Task<IActionResult> AddPrediction3MonthData(Prediction3Month entity){
        _context.Prediction3Month.Add(entity);

        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetPrediction3Month),new {id=entity.StockId},entity);

    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdatePrediction3Month(int id, Prediction3Month entity){

        if(id != entity.StockId){
            return BadRequest();
        }

        var prediction3Month = await _context.Prediction3Month.FirstOrDefaultAsync(i=> i.StockId==id);

        if(prediction3Month==null){
            return NotFound();
        }

        prediction3Month.StockNameAndPrice=entity.StockNameAndPrice;
        prediction3Month.RF=entity.RF;
        prediction3Month.LSTM=entity.LSTM;
        prediction3Month.Prophet=entity.Prophet;
        prediction3Month.StockResultSentiment=entity.StockResultSentiment;
        prediction3Month.SelectPrice=entity.SelectPrice;



        try{
            await _context.SaveChangesAsync();
        }catch(Exception){
            return NotFound();
        }

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletePrediction3Month(int? id){

        if(id == null){
            return NotFound();
        }

        var prediction3Month= await _context.Prediction3Month.FirstOrDefaultAsync(i=>i.StockId==id);

        if(prediction3Month==null){
            return NotFound();
        }

        _context.Prediction3Month.Remove(prediction3Month);

        try{
            await _context.SaveChangesAsync();
        }catch(Exception){
            return NotFound();
        }

        return NoContent();
    }
}
