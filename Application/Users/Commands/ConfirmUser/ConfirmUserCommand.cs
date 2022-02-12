using Application.Common.Interfaces;
using Domain.Consts;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Users.Commands.ConfirmUser
{
    public class ConfirmUserCommand : IRequest<bool>
    {
        public string Token { get; set; }
    }

    public class ConfirmUserCommandHandler : IRequestHandler<ConfirmUserCommand, bool>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly IJwtService _jwtService;

        public ConfirmUserCommandHandler(
            IApplicationDbContext dbContext,
            IJwtService jwtService)
        {
            _dbContext = dbContext;
            _jwtService = jwtService;
        }


        public async Task<bool> Handle(ConfirmUserCommand request, CancellationToken cancellationToken)
        {
            var userIdentity = _jwtService.ValidateToken(request.Token);
            if(userIdentity == null)
            {
                return false;
            }
            
            var user = await _dbContext.Users.FirstOrDefaultAsync(user => user.Id == userIdentity.UserId);
            if(user == null || user.Role != UserRoles.Guest)
            {
                return false;
            }
            user.Role = UserRoles.User;
            await _dbContext.SaveChangesAsync(cancellationToken);
            return true;
        }
    }
}
