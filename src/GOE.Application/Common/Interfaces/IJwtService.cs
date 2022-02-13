using GOE.Application.Common.Models;
using GOE.Domain.Entities;

namespace GOE.Application.Common.Interfaces
{
    public interface IJwtService
    {
        string GenerateJwt(User user);
        UserIdentity ValidateToken(string token);
    }
}
