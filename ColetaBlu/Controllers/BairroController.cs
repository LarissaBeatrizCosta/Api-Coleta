using ColetaBlu.Contracts.Repository;
using Microsoft.AspNetCore.Mvc;

namespace ColetaBlu.Controllers
{
    [ApiController]
    [Route("bairro")]
    public class BairroController : ControllerBase
    {
        private readonly IBairro _bairroRepository;
        public BairroController(IBairro bairroRepository )
        {
            _bairroRepository = bairroRepository;
        }

        [HttpGet]

        public async Task<IActionResult> Get()
        {
            return Ok(await _bairroRepository.Get());
        }
    }
}
