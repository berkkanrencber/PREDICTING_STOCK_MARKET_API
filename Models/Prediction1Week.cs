namespace PREDICTING_STOCK_MARKET_API.Models;

public class Prediction1Week{

    public int StockId { get; set; }
    public string StockNameAndPrice { get; set; } = null!;
    public double RF { get; set; }
    public double LSTM { get; set; }
    public double Prophet { get; set; }
    public string StockResultSentiment { get; set; }= null!;
    public double SelectPrice { get; set; }

}