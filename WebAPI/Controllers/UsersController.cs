using Business.Abstract;
using Core.Paging;
using Domain.DTOs.User;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _service;
        private readonly IOperationClaimService _operationClaimService;

        public UsersController(IUserService service, IOperationClaimService operationClaimService)
        {
            _service = service;
            _operationClaimService = operationClaimService;
        }
        // [SecuredAction("admin")]
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] PageRequest pageRequest)
        {
            var result = await _service.GetAllPaginatedAsync(pageRequest);
            return Ok(result);
        }

        //[SecuredAction("admin")]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _service.GetByIdAsync(id);
            return Ok(result);
        }
        [HttpGet("roles")]
        public async Task<IActionResult> GetRoles([FromQuery] PageRequest pageRequest)
        {
            var result = await _operationClaimService.GetAllPaginatedAsync(pageRequest);
            return Ok(result);
        }

        // [SecuredAction("admin")]
        [HttpPost("AddRoleToUser")]
        public async Task<IActionResult> AddRoleToUser(AddRoleToUserDto dto)
        {
            var result = await _service.AddRoleToUserAsync(dto);
            if (result)
                return Ok(result);
            return BadRequest(result);
        }
        [HttpPost("create-role")]
        public async Task<IActionResult> CreateRole(OperationClaim operationClaim)
        {
            var result = await _operationClaimService.CreateAsync(operationClaim);
            return Ok(result);
        }

        //[HttpDelete("{id}")]
        //public async Task<IActionResult> Delete(int id)
        //{
        //    var result = await _service.DeleteAsync(id);
        //    if (result.Success)
        //    {
        //        return Ok(result);
        //    }
        //    return BadRequest(result);
        //}
    }
}