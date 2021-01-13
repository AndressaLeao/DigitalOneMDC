using CursoAPI.Controllers;
using CursoMDC.Models;
using Microsoft.EntityFrameworkCore;
using Moq;
using System.Threading.Tasks;
using Xunit;

namespace CursoTest
{
    public class CategoriasControllerTest
    {

        private readonly Mock<DbSet<Categoria>> _mockSet;
        private readonly Mock<Context> _mockContext;
        private readonly Categoria _categoria;

       public CategoriasControllerTest()
        {
            _mockSet = new Mock<DbSet<Categoria>>();
            _mockContext = new Mock<Context>();
            _categoria = new Categoria { id = 1, Descricao = "Teste Categoria" };

            _mockContext.Setup(expression: m => m.Categorias).Returns(_mockSet.Object);

            _mockContext.Setup(expression: m => m.Categorias.FindAsync(1))
                .ReturnsAsync(_categoria);
        }

        [Fact]
        public async Task Get_Categoria()
        {
            var service = new CategoriasController(_mockContext.Object);

             await service.GetCategoria(1);

            _mockSet.Verify(expression: m => m.FindAsync(1),
                Times.Once());
        }

    }
}
