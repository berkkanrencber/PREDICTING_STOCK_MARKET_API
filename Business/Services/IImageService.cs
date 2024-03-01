using Microsoft.AspNetCore.Mvc;
using PREDICTING_STOCK_MARKET_API.Core.Result;

namespace PREDICTING_STOCK_MARKET_API.Business.Services;

public interface IImageService {
    
    public IActionResult GetImage(string FilePath);
    public Result UploadImage(IFormFile file);
    public Result DeleteImage(string FileName);
}