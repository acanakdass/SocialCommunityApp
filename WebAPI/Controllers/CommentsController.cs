using AutoMapper;
using Business.Abstract;
using Core.Domain.DTOs;
using Core.Paging;
using Core.Utilities.Dynamic;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly ICommentService _service;
        private readonly IMapper _mapper;

        public CommentsController(ICommentService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        //[TypeFilter(typeof(CacheAspect<PageableListModel<Product>>))]
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] PageRequest pageRequest)
        {
            var result = await _service.GetAllPaginatedAsync(pageRequest);
            return Ok(result);
        }
        // [TypeFilter(typeof(CacheAspect<Product>))]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _service.GetByIdAsync(id);
            return Ok(result);
        }

        //   [TypeFilter(typeof(CacheAspect<PageableListModel<Product>>))]
        [HttpPost("getlistdynamic")]
        public async Task<IActionResult> GetAllDynamic([FromQuery] PageRequest pageRequest, [FromBody] Dynamic dynamic)
        {
            var requestDto = new DynamicPageableListRequestDto()
            {
                PageRequest = pageRequest,
                Dynamic = dynamic
            };
            var result = await _service.GetDynamicListAsync(requestDto);
            return Ok(result);
        }


        //[ValidationAspect(typeof(ProductCreateValidator))]
        // [CacheRemoveAspect("Products.GetAll,Products.GetAllDynamic,Products.GetById,Products.GetAllDynamic")]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Comment createRequestDto)
        {
            var result = await _service.CreateAsync(createRequestDto);
            return Ok(result);
        }

        //[ValidationAspect(typeof(ProductUpdateValidator))]
        //[CacheRemoveAspect("Products.GetAll,Products.GetAllDynamic,Products.GetById,Products.GetAllDynamic")]
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] Comment updateRequestDto)
        {
            var result = await _service.UpdateAsync(updateRequestDto);
            return Ok(result);
        }

    }
}