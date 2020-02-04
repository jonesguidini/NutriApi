using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Nutrivida.Domain.Contracts.Repositories;
using Nutrivida.Domain.DTOs;
using Nutrivida.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Nutrivida.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class FinancialRecordsController : ControllerBase
    {
        private readonly IFinancialRecordRepository _financialRecordRepository;
        private readonly IMapper _mapper;
        public FinancialRecordsController(IFinancialRecordRepository financialRecordRepository, IMapper mapper)
        {
            _mapper = mapper;
            _financialRecordRepository = financialRecordRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var financialRecords = await _financialRecordRepository.GetAll();
            var financialRecordsDto = _mapper.Map<IEnumerable<FinancialRecordDto>>(financialRecords);
            return Ok(financialRecordsDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var financialRecord = await _financialRecordRepository.GetById(id);
            var financialRecordDto = _mapper.Map<FinancialRecordDto>(financialRecord);
            return Ok(financialRecordDto);
        }

        [HttpPost]
        public IActionResult Save(FinancialRecordDto financialRecordDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            // mapeamento
            var financialRecord = _mapper.Map<FinancialRecordDto, FinancialRecord>(financialRecordDto);

            _financialRecordRepository.Add(financialRecord);
            _financialRecordRepository.SaveChanges();

            return Ok("Registro financeiro salvo");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, FinancialRecordDto financialRecordDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var financialRecordBanco = await _financialRecordRepository.GetById(id);

            if (financialRecordBanco == null)
                return BadRequest();

            // mapeia objeto DTO para versão a ser salva
            _mapper.Map(financialRecordDto, financialRecordBanco);

            //_financialRecordRepository.Update(financialRecordBanco);
            _financialRecordRepository.SaveChanges();

            return Ok("Registro financeiro atualizado com sucesso");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var financialRecordBanco = await _financialRecordRepository.GetById(id);

            //_financialRecordRepository.Remove(financialRecordBanco);
            _financialRecordRepository.SaveChanges();

            return Ok("Registro financeiro excluido com sucesso");
        }
    }
}