using Application.Common.Interfaces;
using Domain.Consts;
using Domain.Entities;
using MediatR;

namespace Application.Users.Commands.CreateUser
{
    public class CreateUserCommand : IRequest<User?>
    {
        public string Username { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public DateTime Birthday { get; set; }
        public string Password { get; set; }
    }

    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, User?>
    {

        private readonly IApplicationDbContext _dbContext;

        public CreateUserCommandHandler(
            IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<User?> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var existingUser = 
                _dbContext.Users.FirstOrDefault(user => user.Email == request.Email);

            if(existingUser != null)
            {
                return null;
            }

            var user = new User
            {
                Username = request.Username,
                Firstname = request.Firstname,
                Lastname = request.Lastname,
                Birthday = request.Birthday,
                PhoneNumber = request.PhoneNumber,
                Email = request.Email,
                Password = request.Password,
                Role = UserRoles.Guest,
            };

            await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return user;
        }
    }
}
