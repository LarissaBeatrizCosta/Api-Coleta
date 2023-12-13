using ColetaBlu.Contracts.Repository;
using ColetaBlu.DTO;
using ColetaBlu.Entity;
using Microsoft.AspNetCore.Mvc;

namespace ColetaBlu.Controllers
{
    [ApiController]
    [Route("ponto_de_coleta")]
    public class PontoController : ControllerBase
    {
       
        private readonly IPontoRepository _repository;
        public PontoController(IPontoRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]

        public async Task<IActionResult> Get()
        {
            return Ok(await _repository.Get());
        }

        [HttpPost]
        public async Task<IActionResult> Add(PontoDTO ponto)
        {
            await _repository.Add(ponto);
            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _repository.GetById(id));

        }

        [HttpPut]

        public async Task<IActionResult> Update(PontoEntity ponto)
        {
            await _repository.Update(ponto);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _repository.Delete(id);
            return Ok();
        }

    }
}
