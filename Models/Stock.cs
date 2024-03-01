namespace PREDICTING_STOCK_MARKET_API.Models;

public class Stock{

    public int StockId { get; set; }
    public string StockName { get; set; } = null!;
    public string StockShortName { get; set; } = null!;
    public double StockPrice { get; set; }


}