
using ApiCarros.Models;
using ApiCarros.Service;
using Microsoft.AspNetCore.Mvc;

namespace ApiCarros.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarroController : ControllerBase
    {
        private readonly ICarro _carroInterface;

        public CarroController(ICarro carroInterface)
        {
            _carroInterface = carroInterface;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<CarroModel>>>> GetCarros()
        {
            return Ok(await _carroInterface.GetCarros());
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<CarroModel>>>> CreateCarro(CarroModel novoCarro)
        {
            return Ok(await _carroInterface.CreateCarro(novoCarro));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<CarroModel>>> GetCarroById(int id)
        {
            return Ok(await _carroInterface.GetCarroById(id));
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<CarroModel>>> UpdateCarro(CarroModel carro)
        {
            return Ok(await _carroInterface.UpdateCarro(carro));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResponse<CarroModel>>> DeleteCarro(int id)
        {
            return Ok(await _carroInterface.DeleteCarro(id));
        }
    }
}
