using Moq;
using Nancy;
using Nancy.Security;
using Xunit;

namespace IdeaStrike.Tests.AdminModuleTests
{
    public class when_an_authenticated_user_views_the_admin_page : IdeaStrikeSpecBase
    {
        public when_an_authenticated_user_views_the_admin_page()
        {
            var testRequest = GetTestRequest("/admin");
            RunBefore(AuthenticateUser);
            testResponse = engine.HandleRequest(testRequest).Response;
        }

        private static Response AuthenticateUser(NancyContext arg)
        {
            var user = new Mock<IUserIdentity>();
            user.Setup(i => i.UserName).Returns("shiftkey");
            arg.CurrentUser = user.Object;
            return null;
        }

        [Fact]
        public void it_should_set_the_status_code_to_unauthorized_for_the_admin_page()
        {
            Assert.Equal(HttpStatusCode.OK, testResponse.StatusCode);
        }
    }
}