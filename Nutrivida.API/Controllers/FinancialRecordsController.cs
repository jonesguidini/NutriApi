using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Nutrivida.Domain.Contracts.Managers;
using Nutrivida.Domain.Contracts.Repositories;
using Nutrivida.Domain.Contracts.Services;
using Nutrivida.Domain.DTOs;
using Nutrivida.Domain.Entities;
using Nutrivida.Domain.VMs;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Nutrivida.API.Controllers
{
    [Authorize]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/financialrecords")]
    [ApiController]
    public class FinancialRecordsController : APIController
    {
        private readonly IFinancialRecordsService _financialRecordService;
        private readonly IMapper _mapper;
        public FinancialRecordsController(IFinancialRecordsService financialRecordService, IMapper mapper, INotificationManager _gerenciadorNotificacoes) : base(_gerenciadorNotificacoes)
        {
            _mapper = mapper;
            _financialRecordService = financialRecordService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<FinancialRecordVM>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll()
        {
            IList<string> includes = new List<string> { "Sales", "Expensives"};

            var financialRecords = await _financialRecordService.GetAll(includes);
            var financialRecordsDTO = _mapper.Map<IEnumerable<FinancialRecordVM>>(financialRecords);

            return CustomResponse(financialRecordsDTO);
        }

        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(FinancialRecordVM), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetById(int id)
        {
            IList<string> includes = new List<string> { "Sales", "Expensives", "Sales.SaleCategory", "Expensives.ExpensiveCategory" };
            var financialRecord = await _financialRecordService.GetById(id, includes);

            var financialRecordDTO = _mapper.Map<FinancialRecordVM>(financialRecord);
            return CustomResponse(financialRecordDTO);
        }

        [HttpPost]
        [Route("add")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Create(FinancialRecordDTO financialRecordDTO)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            financialRecordDTO.UserId = 1; // TODO alterar para o id do usuário logado

            await _financialRecordService.Add(financialRecordDTO);

            return CustomResponse("Registro financeiro salvo");
        }

        [HttpPut]
        [Route("update/{id}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Update(int id, FinancialRecordDTO financialRecordDTO)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var financialRecordBanco = await _financialRecordService.GetById(id);

            await _financialRecordService.Update(financialRecordDTO);

            return CustomResponse("Registro financeiro atualizado com sucesso");
        }

        [HttpDelete]
        [Route("delete/{id}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Delete(int id)
        {
            var financialRecordBanco = await _financialRecordService.GetById(id);

            await _financialRecordService.DeleteLogically(financialRecordBanco);

            return CustomResponse("Registro financeiro excluido com sucesso");
        }
    }
}