using Xunit;
using AAAAmESTtKACIOVA;
namespace TestProject1; 
public class AuthorizationTests
{
    [Fact]
    public void GetUser_WithValidCredentials_ReturnsTrue()
    {
        var form = new Form1();
        string testLogin = "testUser"; 
        string testPassword = "testPass";
        
        bool result = form.CheckUserCredentials(testLogin, testPassword);
       
        Assert.True(result);
    }
}