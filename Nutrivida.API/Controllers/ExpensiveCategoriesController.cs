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
    public class ExpensiveCategoriesController : ControllerBase
    {
        private readonly IExpensiveCategoryRepository _expensiveCategoryRepository;
        private readonly IMapper _mapper;
        public ExpensiveCategoriesController(IExpensiveCategoryRepository expensiveCategoryRepository, IMapper mapper)
        {
            _mapper = mapper;
            _expensiveCategoryRepository = expensiveCategoryRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var expensiveCategories = await _expensiveCategoryRepository.GetAll();
            var expensiveCategoriesDto = _mapper.Map<IEnumerable<ExpensiveCategoryDto>>(expensiveCategories);
            return Ok(expensiveCategoriesDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var expensiveCategory = await _expensiveCategoryRepository.GetById(id);
            var expensiveCategoryDto = _mapper.Map<ExpensiveCategoryDto>(expensiveCategory);
            return Ok(expensiveCategoryDto);
        }

        [HttpPost]
        public IActionResult Save(ExpensiveCategoryDto expensiveCategoryDto)
        {

            if (!ModelState.IsValid)
                return BadRequest();

            // mapeamento
            var expensiveCategory = _mapper.Map<ExpensiveCategoryDto, ExpensiveCategory>(expensiveCategoryDto);

            _expensiveCategoryRepository.Add(expensiveCategory);
            _expensiveCategoryRepository.SaveChanges();
            return Ok("Categoria de despesa cadastrada com sucesso");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, ExpensiveCategoryDto expensiveCategoryDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();
                
            var expensiveCategoryBanco = await _expensiveCategoryRepository.GetById(id);

            if (expensiveCategoryBanco == null)
                return BadRequest();

            // mapeamento
            _mapper.Map(expensiveCategoryDto, expensiveCategoryBanco);

            //_expensiveCategoryRepository.Update(expensiveCategoryBanco);
            _expensiveCategoryRepository.SaveChanges();

            return Ok("Categoria de despesas atualizada com sucesso!");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var expensiveCategory = await _expensiveCategoryRepository.GetById(id);

            //_expensiveCategoryRepository.Remove(expensiveCategory);
            _expensiveCategoryRepository.SaveChanges();

            return Ok("Categoria de despesa excluida com sucesso!");
        }
    }
}