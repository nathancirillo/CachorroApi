using Asp.Versioning;
using Deploy.Cachorro.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Deploy.Cachorro.Api.Controllers.v1
{
    
    [ApiController]
    [ApiVersion("1.0")]   
    [Route("api/v{version:apiVersion}/[controller]")]
    public class CachorrosController : ControllerBase
    {
        private readonly CachorroContext _context;

        public CachorrosController(CachorroContext context)
        {
           _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var cachorros = _context.Cachorros.ToList();
            return Ok(cachorros);
        }

        [HttpPost]
        public IActionResult CadastrarCachorro([FromBody] Domain.Cachorro cachorro)
        {
            _context.Cachorros.Add(cachorro);
            return Ok();
        }
    }
   
}
