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
    [Route("api/expensivecategories")]
    [ApiController]
    public class ExpensiveCategoriesController : APIController
    {
        private readonly IExpensiveCategoryRepository _expensiveCategoryRepository;
        private readonly IMapper _mapper;
        public ExpensiveCategoriesController(IExpensiveCategoryRepository expensiveCategoryRepository, IMapper mapper, INotificationManager _gerenciadorNotificacoes) : base(_gerenciadorNotificacoes)
        {
            _mapper = mapper;
            _expensiveCategoryRepository = expensiveCategoryRepository;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<ExpensiveCategoryDTO>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll()
        {
            var expensiveCategories = await _expensiveCategoryRepository.GetAll();
            var expensiveCategoriesDTO = _mapper.Map<IEnumerable<ExpensiveCategoryDTO>>(expensiveCategories);
            return CustomResponse(expensiveCategoriesDTO);
        }

        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(typeof(ExpensiveCategoryDTO), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetById(int id)
        {
            var expensiveCategory = await _expensiveCategoryRepository.GetById(id);

            if (expensiveCategory == null)
            {
                NotificarError("Categoria de Despesa", "A Categoria de despesa informada não existe.");
                return CustomResponse();
            }

            var expensiveCategoryDTO = _mapper.Map<ExpensiveCategoryDTO>(expensiveCategory);
            return CustomResponse(expensiveCategoryDTO);
        }

        [HttpPost]
        [Route("add")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Create(ExpensiveCategoryDTO expensiveCategoryDTO)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            // mapeamento
            var expensiveCategory = _mapper.Map<ExpensiveCategoryDTO, ExpensiveCategory>(expensiveCategoryDTO);

            await _expensiveCategoryRepository.Add(expensiveCategory);
            await _expensiveCategoryRepository.SaveChanges();

            return CustomResponse("Categoria de despesa cadastrada com sucesso");
        }

        [HttpPut]
        [Route("update/{id}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Update(int id, ExpensiveCategoryDTO expensiveCategoryDTO)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var expensiveCategoryBanco = await _expensiveCategoryRepository.GetById(id);

            if (expensiveCategoryBanco == null)
            {
                NotificarError("Categoria de Despesa", "A Categoria de despesa informada não existe.");
                return CustomResponse();
            }

            // mapeamento
            _mapper.Map(expensiveCategoryDTO, expensiveCategoryBanco);

            //_expensiveCategoryRepository.Update(expensiveCategoryBanco);
            await _expensiveCategoryRepository.SaveChanges();

            return CustomResponse("Categoria de despesas atualizada com sucesso!");
        }

        [HttpDelete]
        [Route("delete/{id}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Delete(int id)
        {
            var expensiveCategory = await _expensiveCategoryRepository.GetById(id);

            if (expensiveCategory == null)
            {
                NotificarError("Categoria de Despesa", "A Categoria de despesa informada não existe.");
                return CustomResponse();
            }

            //_expensiveCategoryRepository.Remove(expensiveCategory);
            await _expensiveCategoryRepository.SaveChanges();

            return CustomResponse("Categoria de despesa excluida com sucesso!");
        }
    }
}