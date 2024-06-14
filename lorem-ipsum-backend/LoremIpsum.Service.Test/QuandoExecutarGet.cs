using LoremIpsum.Domain.Interfaces.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoremIpsum.Service.Test
{
    public class QuandoExecutarGet : ClienteTestes
    {
        private IClienteService _service;
        private Mock<IClienteService> _serviceMock;

        [Fact]
        public async Task E_Possivel_Executar_Get()
        {
            _serviceMock = new Mock<IClienteService>();
            _serviceMock.Setup(s => s.Get(clienteId)).ReturnsAsync(cliente);
            _service = _serviceMock.Object;

            var result = await _service.Get(clienteId);

            Assert.NotNull(result);
            Assert.True(result.Id == clienteId);
        } 

    }
}
