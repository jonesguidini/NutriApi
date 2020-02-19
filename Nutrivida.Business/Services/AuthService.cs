using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Nutrivida.Domain.Contracts.FluentValidation;
using Nutrivida.Domain.Contracts.Managers;
using Nutrivida.Domain.Contracts.Repositories;
using Nutrivida.Domain.Contracts.Services;
using Nutrivida.Domain.Entities;

namespace Nutrivida.Business.Services
{
    public class AuthService : ServiceBase<User>, IAuthService
    {
        private readonly IHttpContextAccessor _httpContextAcessor;

        public AuthService(IUserRepository _repository, IHttpContextAccessor httpContextAcessor, INotificationManager _gerenciadorNotificacoes, IMapper _mapper, IFluentValidation<User> _fluentValidation) : base(_repository, _gerenciadorNotificacoes, _mapper, _fluentValidation)
        {
            _httpContextAcessor = httpContextAcessor;
        }

        public string GetClaims(string chave)
        {
            string listaClaimsValues = "";

            var filtroClaims = _httpContextAcessor.HttpContext.User.Claims
                .GroupBy(claim => claim.Type)
                .ToList().Where(x => x.Key.ToLower() == chave.ToLower())
                .Select(b => b)
                .ToDictionary(group => group.Key, group => group).Values.FirstOrDefault();

            if (chave.ToLower() == ClaimTypes.Role.ToLower())
            {
                listaClaimsValues = String.Join(", ", filtroClaims.Select(x => x.Value).ToList());
            }
            else
            {
                listaClaimsValues = filtroClaims?.FirstOrDefault()?.Value;
            }

            return listaClaimsValues;

        }
    }
}
