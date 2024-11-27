using Xunit;
using Moq;
using System.Data.SqlClient;
using AAAAmESTtKACIOVA;
public class UserAuthTests
{
    [Fact]
    public void CheckUserCredentials_ValidUser_ReturnsTrue()
    {        
        var auth = new UserAuth();
        string testLogin = "validUser";
        string testPassword = "validPass";
        bool result = auth.CheckUserCredentials(testLogin, testPassword);
       
        Assert.True(result);
    }
    [Fact]
    public void CheckUserCredentials_InvalidUser_ReturnsFalse()
    {
             var auth = new UserAuth();
       
        string testLogin = "invalidUser"; string testPassword = "wrongPass";
       
        bool result = auth.CheckUserCredentials(testLogin, testPassword);
         Assert.False(result);
    }
}