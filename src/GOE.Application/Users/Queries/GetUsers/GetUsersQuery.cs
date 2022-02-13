using GOE.Application.Common.Interfaces;
using GOE.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace GOE.Application.Users.Queries.GetUsers
{
    public class GetUsersQuery : IRequest<List<User>>
    {

    }
    public class GetUsersQueryHandler : IRequestHandler<GetUsersQuery, List<User>>
    {
        private readonly IApplicationDbContext dbContext;

        public GetUsersQueryHandler(IApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<List<User>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
        {
            return await dbContext.Users.ToListAsync();
        }
    }
}
