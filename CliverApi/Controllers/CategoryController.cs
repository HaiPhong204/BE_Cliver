using CliverApi.Core.Contracts;
using CliverApi.DTOs;
using CliverApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CliverApi.Controllers
{
    [Route("api/categories")]
    [ApiController]
    public class CategoryController : ControllerBase
    {

        private readonly IUnitOfWork _unitOfWork;
        public CategoryController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        [Route("Category")]
        public async Task<IActionResult> GetPopularCategories()
        {
            var categories = await _unitOfWork.Categories.GetPopularCategory();
            return Ok(new ApiResponse<IEnumerable<Category>>(categories, "Get successfully"));
        }
    }
}
