
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Nutrivida.Domain.Contracts.Managers;
using Nutrivida.Domain.Contracts.Repositories;
using Nutrivida.Domain.DTOs;
using Nutrivida.Domain.Entities;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Nutrivida.API.Controllers
{
    [Route("api/authentication")]
    [ApiController]
    public class AuthController : APIController
    {
        private readonly IAuthRepository _repo;

        public IConfiguration _config { get; }
        private readonly IMapper _mapper;

        public AuthController(IAuthRepository repo, IConfiguration config, IMapper mapper, INotificationManager _gerenciadorNotificacoes) : base(_gerenciadorNotificacoes)
        {
            _mapper = mapper;
            _repo = repo;
            _config = config;
        }

        [Authorize]
        [HttpPost]
        [Route("add")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Register(UserForRegisterDto userRegisterDto)
        {

            userRegisterDto.Username = userRegisterDto.Username.ToLower();

            if (await _repo.UserExists(userRegisterDto.Username))
            {
                NotificarError("Usuário", "Já existe um usuário cadastrado com esse login.");
                return CustomResponse();
            }

            // TODO: ajustar mapeamento
            var userToCreate = new User()
            {
                Username = userRegisterDto.Username,
                Email = userRegisterDto.Email
            };

            var createdUser = await _repo.Register(userToCreate, userRegisterDto.Password);

            return CustomResponse(createdUser);
        }

        [HttpPost]
        [Route("login")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Login(UserForLoginDto userForLoginDto)
        {
            var userFromRepo = await _repo.Login(userForLoginDto.Username.ToLower(), userForLoginDto.Password);

            if (userFromRepo == null)
            {
                NotificarError("Login", "Usuário ou senha não conferem.");
                return CustomResponse();
                //return Unauthorized();
            }

            // cria dois claims
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, userFromRepo.Id.ToString()),
                new Claim(ClaimTypes.Name, userFromRepo.Username)
            };

            // cria a key a ser usada na credencial em base do token informado no arquivo appsettings.json
            var key = new SymmetricSecurityKey(Encoding.UTF8
                .GetBytes(_config.GetSection("AppSettings:Token").Value));

            // cria a credencial
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            // Cria estrutura do token
            var tokenDecriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims), // com base nas claims já criada anteriormente
                Expires = DateTime.Now.AddDays(1), // expira em 1 dia   
                SigningCredentials = credentials // com base na credencial criada anteiormente
            };

            // cria um handler de token a ser usando para gerar o token
            var tokenHandler = new JwtSecurityTokenHandler();

            // gera o token
            var token = tokenHandler.CreateToken(tokenDecriptor);

            // retorna o tolen gerado
            return CustomResponse(new
            {
                token = tokenHandler.WriteToken(token)
            });

        }
    }
}