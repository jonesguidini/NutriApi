using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Nutrivida.Domain.Contracts.FluentValidation;
using Nutrivida.Domain.Contracts.Managers;
using Nutrivida.Domain.Contracts.Repositories;
using Nutrivida.Domain.Contracts.Services;
using Nutrivida.Domain.Entities;

namespace Nutrivida.Business.Services
{
    public class AuthService : ServiceBase<User>, IAuthService
    {
        public AuthService(IUserRepository _repository, INotificationManager _gerenciadorNotificacoes, IMapper _mapper, IFluentValidation<User> _fluentValidation) : base(_repository, _gerenciadorNotificacoes, _mapper, _fluentValidation)
        {

        }
    }
}
