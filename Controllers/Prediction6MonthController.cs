using System.Net.Http.Headers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PREDICTING_STOCK_MARKET_API.Models;

namespace PREDICTING_STOCK_MARKET_API.Controllers;


// localhost:8080/api/prediction6month
[ApiController]
[Route("api/prediction6month")]
public class Prediction6MonthController:ControllerBase{

    private readonly StocksContext _context;

    public Prediction6MonthController(StocksContext context)
    {
        _context = context;
    }

    // localhost:8080/api/prediction6month => GET
    [HttpGet]
    public async Task<IActionResult> GetPrediction6Months(){
        
        var prediction6month = await _context.Prediction6Month.ToListAsync();
        return Ok(prediction6month);
    }

    // localhost:8080/api/prediction6month/1 => GET
    [Authorize]
    [HttpGet("{id}")]
    public async Task<IActionResult> GetPrediction6Month(int? id){
        
        if(id==null){
            return NotFound();
        }

        var s = await _context.Prediction6Month.FirstOrDefaultAsync(i=>i.StockId==id);

        if(s==null){
            return NotFound();
        }

        return Ok(s);
    }

    [HttpPost]
    public async Task<IActionResult> AddPrediction6MonthData(Prediction6Month entity){
        _context.Prediction6Month.Add(entity);

        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetPrediction6Month),new {id=entity.StockId},entity);

    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdatePrediction6Month(int id, Prediction6Month entity){

        if(id != entity.StockId){
            return BadRequest();
        }

        var prediction6Month = await _context.Prediction6Month.FirstOrDefaultAsync(i=> i.StockId==id);

        if(prediction6Month==null){
            return NotFound();
        }

        prediction6Month.StockNameAndPrice=entity.StockNameAndPrice;
        prediction6Month.RF=entity.RF;
        prediction6Month.LSTM=entity.LSTM;
        prediction6Month.Prophet=entity.Prophet;
        prediction6Month.StockResultSentiment=entity.StockResultSentiment;
        prediction6Month.SelectPrice=entity.SelectPrice;



        try{
            await _context.SaveChangesAsync();
        }catch(Exception){
            return NotFound();
        }

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletePrediction6Month(int? id){

        if(id == null){
            return NotFound();
        }

        var prediction6Month= await _context.Prediction6Month.FirstOrDefaultAsync(i=>i.StockId==id);

        if(prediction6Month==null){
            return NotFound();
        }

        _context.Prediction6Month.Remove(prediction6Month);

        try{
            await _context.SaveChangesAsync();
        }catch(Exception){
            return NotFound();
        }

        return NoContent();
    }
}
