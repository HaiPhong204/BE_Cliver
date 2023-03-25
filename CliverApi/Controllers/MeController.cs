using AutoMapper;
using CliverApi.Attributes;
using CliverApi.Core.Contracts;
using CliverApi.DTOs;
using CliverApi.DTOs.RequestFeatures;
using CliverApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CliverApi.Controllers
{
    [Route("api/me")]
    [ApiController]
    [Protect]
    public class MeController : ControllerBase
    {
        public IUnitOfWork _unitOfWork{ get; set; }
        public IMapper _mapper{ get; set; }

        public MeController(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        // GET api/posts/:id/recently
        //[HttpGet("{id}")]
        //[Protect]
        //[Produces(typeof(ApiResponse<IEnumerable<PostDto>>))]
        //public async Task<IActionResult> GetRecentPosts([FromQuery] RecentPostParameters recentPostParameters)
        //{
        //    var user = HttpContext.Items["User"] as User;
        //    var posts = await _unitOfWork.RecentPosts.GetRecentPosts(user!.Id, recentPostParameters);
        //    var metaData = (posts as PagedList<Post>)?.MetaData;

        //    var postDto = _mapper.Map<IEnumerable<PostDto>>(posts);
        //    return Ok(new ApiResponse<IEnumerable<PostDto>>(postDto, "Get my recent posts successfully", metaData));
        //}

    }
}
