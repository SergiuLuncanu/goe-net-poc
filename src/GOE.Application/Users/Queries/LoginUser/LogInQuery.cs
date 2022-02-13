using GOE.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace GOE.Application.Users.Queries.LoginUser
{
    public class LogInUserQuery : IRequest<string>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }

    public class LoginUserQueryHandler : IRequestHandler<LogInUserQuery, string>
    {
        private readonly IApplicationDbContext dbContext;
        private readonly IJwtService jwtService;

        public LoginUserQueryHandler(
            IApplicationDbContext dbContext,
            IJwtService jwtService)
        {
            this.dbContext = dbContext;
            this.jwtService = jwtService;
        }

        public async Task<string> Handle(LogInUserQuery request, CancellationToken cancellationToken)
        {
            var user = await dbContext.Users.FirstOrDefaultAsync(user => user.Email == request.Email && user.Password == request.Password);
            if (user == null)
            {
                return "";
            }
            return jwtService.GenerateJwt(user);
        }
    }
}
