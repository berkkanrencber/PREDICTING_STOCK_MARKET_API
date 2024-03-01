using Microsoft.AspNetCore.Mvc;
using PREDICTING_STOCK_MARKET_API.Business.Services;
using PREDICTING_STOCK_MARKET_API.Business.Managers;
using PREDICTING_STOCK_MARKET_API.Core.Result;

namespace PREDICTING_STOCK_MARKET_API.Controllers;

[ApiController]
[Route("api/[controller]s")]
public class ImageController : ControllerBase {

    private readonly IImageService _service;

    public ImageController() {
        _service = new ImageManager();
    }

    [HttpGet("GetImage/{FilePath}")]
    public IActionResult GetImage(string FilePath) {
        return _service.GetImage(FilePath);
    }

    /* [HttpPost("UploadImage")]
    public Result UploadImage([FromForm] IFormFile file) {
        return _service.UploadImage(file);
    }

    [HttpDelete("DeleteImage/{FileName}")]
    public Result DeleteImage(string FileName) {
        return _service.DeleteImage(FileName);
    } */

}