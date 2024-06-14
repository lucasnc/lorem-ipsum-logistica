using Microsoft.AspNetCore.Mvc;
using LoremIpsum.Domain.Interfaces.Services;
using LoremIpsum.Domain.Dtos;

namespace lorem_ipsum_api.Controllers
{
    [Route("cliente")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private IClienteService _service;
        public ClienteController(IClienteService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(await _service.GetAll());

        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(await _service.Get(id));
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] ClienteDtoCreate cliente)
        {

            var result = await _service.Post(cliente);
            return Ok(result);
        }

        [HttpPut]
        public async Task<ActionResult> Put([FromBody] ClienteDtoUpdate cliente)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _service.Put(cliente);
            if (result != null)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest();
            }

        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(await _service.Delete(id));
        }
    }
}
