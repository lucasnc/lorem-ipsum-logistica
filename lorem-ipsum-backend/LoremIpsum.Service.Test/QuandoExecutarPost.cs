using LoremIpsum.Domain.Interfaces.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoremIpsum.Service.Test
{
    public class QuandoExecutarPost : ClienteTestes
    {
        private IClienteService _service;
        private Mock<IClienteService> _serviceMock;

        [Fact]
        public async Task E_Possive_Executar_Post()
        {
            _serviceMock = new Mock<IClienteService>();
            _serviceMock.Setup(s => s.Post(clienteDtoCreate)).ReturnsAsync(clienteDtoResult);
            _service = _serviceMock.Object;

            var result = await _service.Post(clienteDtoCreate);

            Assert.NotNull(result);
            Assert.True(result.Nome == clienteDtoCreate.Nome);
        }
    }
}
