using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Nutrivida.Domain.Contracts.Managers;
using Nutrivida.Domain.Contracts.Repositories;
using Nutrivida.Domain.Contracts.Services;
using Nutrivida.Domain.DTOs;
using Nutrivida.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Nutrivida.API.Controllers
{
    [Authorize]
    [Route("api/financialrecords")]
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
        [ProducesResponseType(typeof(IEnumerable<FinancialRecordDTO>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll()
        {
            var financialRecords = await _financialRecordService.GetAll();
            var financialRecordsDTO = _mapper.Map<IEnumerable<FinancialRecordDTO>>(financialRecords);
            return CustomResponse(financialRecordsDTO);
        }

        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(FinancialRecordDTO), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetById(int id)
        {
            var financialRecord = await _financialRecordService.GetById(id);

            if(financialRecord == null)
            {
                NotificarError("Registro Financeiro", "Registro Financeiro não encontrado.");
                return CustomResponse();
            }

            var financialRecordDTO = _mapper.Map<FinancialRecordDTO>(financialRecord);
            return CustomResponse(financialRecordDTO);
        }

        [HttpPost]
        [Route("add")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Create(FinancialRecordDTO financialRecordDTO)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

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

            if (financialRecordBanco == null)
            {
                NotificarError("Registro Financeiro", "Registro Financeiro não encontrado.");
                return CustomResponse();
            }

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

            if (financialRecordBanco == null)
            {
                NotificarError("Registro Financeiro", "Registro Financeiro não encontrado.");
                return CustomResponse();
            }

            await _financialRecordService.Delete(id);

            return CustomResponse("Registro financeiro excluido com sucesso");
        }
    }
}