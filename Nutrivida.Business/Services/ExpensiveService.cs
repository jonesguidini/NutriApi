using AutoMapper;
using Nutrivida.Domain.Contracts.FluentValidation;
using Nutrivida.Domain.Contracts.Managers;
using Nutrivida.Domain.Contracts.Repositories;
using Nutrivida.Domain.Contracts.Services;
using Nutrivida.Domain.Entities;

namespace Nutrivida.Business.Services
{
    public class ExpensiveService : ServiceBase<Expensive>, IExpensiveService
    {
        public ExpensiveService(IExpensiveRepository _repository, INotificationManager _gerenciadorNotificacoes, IMapper _mapper, IFluentValidation<Expensive> _fluentValidation) : base(_repository, _gerenciadorNotificacoes, _mapper, _fluentValidation)
        {
        }
    }
}
