namespace PREDICTING_STOCK_MARKET_API.Models;

public class Sentiment1Month{

    public int StockId { get; set; }
    public string StockName { get; set; } = null!;
    public string StockGeneralSentiment { get; set; } = null!;
    public string StockRetweetSentiment { get; set; }= null!;
    public string StockReplySentiment { get; set; }= null!;
    public string StockLikeSentiment { get; set; }= null!;
    public string StockResultSentiment { get; set; }= null!;

}