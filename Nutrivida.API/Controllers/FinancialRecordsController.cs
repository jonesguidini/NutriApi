using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Nutrivida.Domain.Contracts.Managers;
using Nutrivida.Domain.Contracts.Repositories;
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
        private readonly IFinancialRecordRepository _financialRecordRepository;
        private readonly IMapper _mapper;
        public FinancialRecordsController(IFinancialRecordRepository financialRecordRepository, IMapper mapper, INotificationManager _gerenciadorNotificacoes) : base(_gerenciadorNotificacoes)
        {
            _mapper = mapper;
            _financialRecordRepository = financialRecordRepository;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<FinancialRecordDTO>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll()
        {
            var financialRecords = await _financialRecordRepository.GetAll();
            var financialRecordsDTO = _mapper.Map<IEnumerable<FinancialRecordDTO>>(financialRecords);
            return CustomResponse(financialRecordsDTO);
        }

        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(FinancialRecordDTO), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetById(int id)
        {
            var financialRecord = await _financialRecordRepository.GetById(id);

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
        public IActionResult Create(FinancialRecordDTO financialRecordDTO)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            // mapeamento
            var financialRecord = _mapper.Map<FinancialRecordDTO, FinancialRecord>(financialRecordDTO);

            _financialRecordRepository.Add(financialRecord);
            _financialRecordRepository.SaveChanges();

            return CustomResponse("Registro financeiro salvo");
        }

        [HttpPut]
        [Route("update/{id}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Update(int id, FinancialRecordDTO financialRecordDTO)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var financialRecordBanco = await _financialRecordRepository.GetById(id);

            if (financialRecordBanco == null)
            {
                NotificarError("Registro Financeiro", "Registro Financeiro não encontrado.");
                return CustomResponse();
            }

            // mapeia objeto DTO para versão a ser salva
            _mapper.Map(financialRecordDTO, financialRecordBanco);

            //_financialRecordRepository.Update(financialRecordBanco);
            await _financialRecordRepository.SaveChanges();

            return CustomResponse("Registro financeiro atualizado com sucesso");
        }

        [HttpDelete]
        [Route("delete/{id}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Delete(int id)
        {
            var financialRecordBanco = await _financialRecordRepository.GetById(id);

            if (financialRecordBanco == null)
            {
                NotificarError("Registro Financeiro", "Registro Financeiro não encontrado.");
                return CustomResponse();
            }

            //_financialRecordRepository.Remove(financialRecordBanco);
            await _financialRecordRepository.SaveChanges();

            return CustomResponse("Registro financeiro excluido com sucesso");
        }
    }
}