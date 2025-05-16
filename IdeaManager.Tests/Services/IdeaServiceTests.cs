using Xunit;
using IdeaManager.Core.Entities;
using IdeaManager.Core.Interfaces;
using Moq;

namespace IdeaManager.Tests.Services
{
    public class IdeaServiceTests
    {
        private readonly Mock<IUnitOfWork> _unitOfWorkMock;
        private readonly Mock<IRepository<Idea>> _ideaRepositoryMock;
        private readonly IdeaService _ideaService;

        public IdeaServiceTests()
        {
            _unitOfWorkMock = new Mock<IUnitOfWork>();
            _ideaRepositoryMock = new Mock<IRepository<Idea>>();
            _unitOfWorkMock.Setup(u => u.IdeaRepository).Returns(_ideaRepositoryMock.Object);

            _ideaService = new IdeaService(_unitOfWorkMock.Object);
        }

        [Fact]
        public async Task SubmitIdeaAsync_ShouldThrowException_WhenTitleIsEmpty()
        {
            // Arrange
            var idea = new Idea { Title = "" };

            // Act & Assert
            var exception = await Assert.ThrowsAsync<ArgumentException>(() => _ideaService.SubmitIdeaAsync(idea));
            Assert.Equal("Le titre est obligatoire.", exception.Message);
        }
    }
}
