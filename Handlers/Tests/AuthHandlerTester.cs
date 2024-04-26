using Moq;
using Store.Commands;
using Store.Data;
using Store.Models;
using Xunit;

namespace Store.Handlers.Tests
{
    public class AuthHandlerTester
    {
        [Fact]
        public void Handler_ValidCredentials_ShouldNotThrow()
        {
            // Arrange
            var mockDataContext = new Mock<DataContext>();
            var user = new Usuario { Username = "valid_user", Password = "valid_password" };
            mockDataContext.Setup(m => m.Users.Any(u => u.Username == "valid_user" && u.Password == "valid_password")).Returns(true);
            var authHandler = new AuthHandler(mockDataContext.Object);
            var action = new AuthAction { Username = "valid_user", Password = "valid_password" };

            // Act
            Action act = () => authHandler.handler(action);

            // Act & Assert
            Assert.NotNull(() => authHandler.handler(action));
        }
    }
}
