using BuberDinner.Application.Common.Interfaces;

namespace BuberDinner.Application.Services.Authentication
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IJwtTokenGenerator _jwTokenGenerator;

        public AuthenticationService(IJwtTokenGenerator jwTokenGenerator)
        {
            _jwTokenGenerator = jwTokenGenerator;
        }

        public AuthenticationResult Register(string firstName, string lastName, string email, string password)
        {

            Guid userId = Guid.NewGuid();
            string token = _jwTokenGenerator.GenerateToken(userId, firstName, lastName);

            return new AuthenticationResult(
                Guid.NewGuid(),
                firstName,
                lastName,
                email,
                token);
        }

        public AuthenticationResult Login(string email, string password)
        {
            return new AuthenticationResult(
                Guid.NewGuid(),
                "firstName",
                "lastName",
                email,
                "token");
        }
    }
}