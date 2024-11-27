using Xunit;
using AAAAmESTtKACIOVA;  // ”бедитесь, что это пространство имен совпадает

namespace TestProject1
{
    public class UserAuthTests
    {
        [Fact]
        public void CheckUserCredentials_ValidUser_ReturnsTrue()
        {
            // Arrange  
            var auth = new UserAuth();
            string validLogin = "testUser";
            string validPassword = "testPassword";

            // Act  
            bool result = auth.CheckUserCredentials(validLogin, validPassword);

            // Assert  
            Assert.True(result);
        }

        [Fact]
        public void CheckUserCredentials_InvalidUser_ReturnsFalse()
        {
            // Arrange  
            var auth = new UserAuth();
            string invalidLogin = "wrongUser";
            string invalidPassword = "wrongPassword";

            // Act  
            bool result = auth.CheckUserCredentials(invalidLogin, invalidPassword);

            // Assert  
            Assert.False(result);
        }
    }
}