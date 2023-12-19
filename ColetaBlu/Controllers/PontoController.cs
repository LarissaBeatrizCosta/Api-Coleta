using ColetaBlu.Contracts.Repository;
using ColetaBlu.DTO;
using ColetaBlu.Entity;
using Microsoft.AspNetCore.Authorization;
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

        [Authorize(Roles = "admin, coletor")]
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _repository.Get());
        }
        [Authorize(Roles = "admin")]
        [HttpPost]
        public async Task<IActionResult> Add(PontoDTO ponto)
        {
            await _repository.Add(ponto);
            return Ok();
        }
        [Authorize(Roles = "admin")]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _repository.GetById(id));

        }
        [Authorize(Roles = "admin,coletor")]
        [HttpPut]

        public async Task<IActionResult> Update(PontoEntity ponto)
        {
            await _repository.Update(ponto);
            return Ok();
        }
        [Authorize(Roles = "admin")]
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _repository.Delete(id);
            return Ok();
        }


        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> LogIn(PontoLoginDTO ponto)
        {
            try
            {
                return Ok(await _repository.LogIn(ponto));
            }
            catch (Exception ex)
            {
                return Unauthorized("Número inválido");
            }
        }
    }
}
