using System.Net.Http.Headers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PREDICTING_STOCK_MARKET_API.Models;

namespace PREDICTING_STOCK_MARKET_API.Controllers;

// localhost:8080/api/stocks
[ApiController]
[Route("api/stocks")]
public class StocksController:ControllerBase{

    private readonly StocksContext _context;

    public StocksController(StocksContext context)
    {
        _context = context;
    }

    // localhost:8080/api/stocks => GET
    [HttpGet]
    public async Task<IActionResult> GetStocks(){
        
        var stocks = await _context.Stock.ToListAsync();
        return Ok(stocks);
    }

    // localhost:8080/api/stocks/1 => GET
    [Authorize]
    [HttpGet("{id}")]
    public async Task<IActionResult> GetStock(int? id){
        
        if(id==null){
            return NotFound();
        }

        var s = await _context.Stock.FirstOrDefaultAsync(i=>i.StockId==id);

        if(s==null){
            return NotFound();
        }

        return Ok(s);
    }

    [HttpPost]
    public async Task<IActionResult> AddStock(Stock entity){
        _context.Stock.Add(entity);

        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetStock),new {id=entity.StockId},entity);

    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateStock(int id, Stock entity){

        if(id != entity.StockId){
            return BadRequest();
        }

        var stock = await _context.Stock.FirstOrDefaultAsync(i=> i.StockId==id);

        if(stock==null){
            return NotFound();
        }

        stock.StockName=entity.StockName;
        stock.StockShortName=entity.StockShortName;
        stock.StockPrice=entity.StockPrice;

        try{
            await _context.SaveChangesAsync();
        }catch(Exception){
            return NotFound();
        }

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteStock(int? id){

        if(id == null){
            return NotFound();
        }

        var stock= await _context.Stock.FirstOrDefaultAsync(i=>i.StockId==id);

        if(stock==null){
            return NotFound();
        }

        _context.Stock.Remove(stock);

        try{
            await _context.SaveChangesAsync();
        }catch(Exception){
            return NotFound();
        }

        return NoContent();
    }
}