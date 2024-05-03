using System.Net.Http.Headers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PREDICTING_STOCK_MARKET_API.Models;

namespace PREDICTING_STOCK_MARKET_API.Controllers;


// localhost:8080/api/prediction1month
[ApiController]
[Route("api/prediction1month")]
public class Prediction1MonthController:ControllerBase{

    private readonly StocksContext _context;

    public Prediction1MonthController(StocksContext context)
    {
        _context = context;
    }

    // localhost:8080/api/prediction1month => GET
    [HttpGet]
    public async Task<IActionResult> GetPrediction1Months(){
        
        var prediction1month = await _context.Prediction1Month.ToListAsync();
        return Ok(prediction1month);
    }

    // localhost:8080/api/prediction1month/1 => GET
    [Authorize]
    [HttpGet("{id}")]
    public async Task<IActionResult> GetPrediction1Month(int? id){
        
        if(id==null){
            return NotFound();
        }

        var s = await _context.Prediction1Month.FirstOrDefaultAsync(i=>i.StockId==id);

        if(s==null){
            return NotFound();
        }

        return Ok(s);
    }

    [HttpPost]
    public async Task<IActionResult> AddPrediction1MonthData(Prediction1Month entity){
        _context.Prediction1Month.Add(entity);

        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetPrediction1Month),new {id=entity.StockId},entity);

    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdatePrediction1Month(int id, Prediction1Month entity){

        if(id != entity.StockId){
            return BadRequest();
        }

        var prediction1Month = await _context.Prediction1Month.FirstOrDefaultAsync(i=> i.StockId==id);

        if(prediction1Month==null){
            return NotFound();
        }

        prediction1Month.StockNameAndPrice=entity.StockNameAndPrice;
        prediction1Month.RF=entity.RF;
        prediction1Month.LSTM=entity.LSTM;
        prediction1Month.Prophet=entity.Prophet;
        prediction1Month.StockResultSentiment=entity.StockResultSentiment;
        prediction1Month.SelectPrice=entity.SelectPrice;



        try{
            await _context.SaveChangesAsync();
        }catch(Exception){
            return NotFound();
        }

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletePrediction1Month(int? id){

        if(id == null){
            return NotFound();
        }

        var prediction1Month= await _context.Prediction1Month.FirstOrDefaultAsync(i=>i.StockId==id);

        if(prediction1Month==null){
            return NotFound();
        }

        _context.Prediction1Month.Remove(prediction1Month);

        try{
            await _context.SaveChangesAsync();
        }catch(Exception){
            return NotFound();
        }

        return NoContent();
    }
}
