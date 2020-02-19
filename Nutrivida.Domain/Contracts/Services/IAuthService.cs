using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using Nutrivida.Domain.Entities;

namespace Nutrivida.Domain.Contracts.Services
{
    public interface IAuthService : IServiceBase<User>
    {
        string GetClaims(string chave);
    }
}
