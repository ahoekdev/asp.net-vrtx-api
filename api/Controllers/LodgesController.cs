using api.DTOs;
using api.Entities;
using api.Mapping;
using api.Services;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class Lodges(LodgeService lodgeService) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<List<Lodge>>> GetAll()
        {
            var list = await lodgeService.GetAllAsync();

            return Ok(list);
        }

        [HttpPost]
        public async Task<ActionResult<Lodge>> Create(LodgeDto dto)
        {
            var lodge = await lodgeService.AddAsync(LodgeMapper.ToEntity(dto));
            return lodge;
        }
    }
}