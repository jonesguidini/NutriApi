using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Nutrivida.Domain.Contracts.Repositories;
using Nutrivida.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Nutrivida.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public UsersController(IUserRepository userRepository, IMapper mapper)
        {
            _mapper = mapper;
            _userRepository = userRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var users = await _userRepository.GetAll();
            var usersDto = _mapper.Map<IEnumerable<UserDto>>(users);
            return Ok(usersDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var user = await _userRepository.GetById(id);
            var userDto = _mapper.Map<UserDto>(user);
            return Ok(userDto);
        }

        // [HttpPost]  --- Já existe cadastro no AuthControllerRegister
        // public IActionResult Save(User user){
        //     _userRepository.add(user);
        //     _userRepository.SaveChanges();
        //     return Ok("Usuário cadastrado com sucesso");
        // }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UserDto userDto)
        {

            if(!ModelState.IsValid)
                return BadRequest();

            var userBanco = await _userRepository.GetById(id);

            if(userBanco == null)
                return BadRequest();

            // mapper
            _mapper.Map(userDto, userBanco);

            //_userRepository.Update(userBanco);
            _userRepository.SaveChanges();

            return Ok("Usuário cadastrado com sucesso");
        }
    }
}