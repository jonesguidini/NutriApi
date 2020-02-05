using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Nutrivida.API.Data;
using Nutrivida.Domain.Contracts.Managers;
using Nutrivida.Domain.Contracts.Repositories;
using Nutrivida.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Nutrivida.API.Controllers
{
    [Authorize]
    [Route("api/users")]
    [ApiController]
    public class UsersController : APIController
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public UsersController(IUserRepository userRepository, IMapper mapper, INotificationManager _gerenciadorNotificacoes) : base(_gerenciadorNotificacoes)
        {
            _mapper = mapper;
            _userRepository = userRepository;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetAll()
        {
            var users = await _userRepository.GetAll();
            var usersDto = _mapper.Map<IEnumerable<UserForRegisterDto>>(users);
            //return CustomResponse(usersDto);
            return CustomResponse(usersDto);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var user = await _userRepository.GetById(id);

            if (user == null)
            {
                NotificarError("Usuário", "O usuário informado não existe.");
                return CustomResponse();
            }

            var userDto = _mapper.Map<UserForRegisterDto>(user);
            //return CustomResponse(userDto);
            return CustomResponse(userDto);
        }

        // [HttpPost]  --- Já existe cadastro no AuthControllerRegister
        // public IActionResult Save(User user){
        //     _userRepository.add(user);
        //     _userRepository.SaveChanges();
        //     return CustomResponse("Usuário cadastrado com sucesso");
        // }

        [HttpPut]
        [Route("update/{id}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Update(int id, UserForRegisterDto userDto)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var userBanco = await _userRepository.GetById(id);

            if(userBanco == null)
            {
                NotificarError("Usuário", "Não existe um usuário para o ID informado.");
                return CustomResponse();
            }

            // mapper
            _mapper.Map(userDto, userBanco);

            //_userRepository.Update(userBanco);
            await _userRepository.SaveChanges();

            return CustomResponse(userBanco);
        }
    }
}