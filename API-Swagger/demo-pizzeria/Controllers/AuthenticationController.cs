using AutoMapper;
using demo_pizzeria.Data;
using demo_pizzeria.DTOs;
using demo_pizzeria.Helpers;
using demo_pizzeria.Models;
using EFHelper.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Win32;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace demo_pizzeria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IRepository<User> _userRepository;
        private readonly AppSettings _settings;
        private readonly IMapper _mapper;
        private readonly string _securityPasswordKey = "clé super secrète";

        public AuthenticationController(IOptions<AppSettings> appSettings, IMapper mapper, IRepository<User> userRepository)
        {
            _userRepository = userRepository;
            _settings = appSettings.Value;
            _mapper = mapper;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequestDTO register)
        {
            if (_userRepository.Get(u => u.Email == register.Email) != null) // on a un utilisateur existant avec cet email
                return BadRequest("Email is already taken");

            //chiffrage du mdp
            register.Password = EncryptPassword(register.Password);

            var user = _mapper.Map<RegisterRequestDTO, User>(register);

            int id = await _userRepository.AddAsync(user);
            user.Id = id;
            var token = GetJWTToken(user, true);

            var registerResponseDTO = _mapper.Map<User, RegisterResponseDTO>(user);
            if (id > 0) return Ok(new { Token = token, Message = "User registered", User = registerResponseDTO });
            return BadRequest("Something went wrong...");
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDTO login)
        {
            login.Password = EncryptPassword(login.Password);

            var user = await _userRepository.GetAsync(u => u.Email == login.Email && u.Password == login.Password);

            if (user == null) return BadRequest("Invalid Authentication !");

            var loginResponseDTO = _mapper.Map<User, LoginResponseDTO>(user);

            var token = GetJWTToken(user);

            return Ok(new
            {
                Token = token,
                Message = "Authentication successfull !!!!!!!",
                User = loginResponseDTO
            });
        }

        [NonAction]
        private string GetJWTToken(User user, bool isRegistering = false)
        {
            var role = isRegistering ? Constants.RoleUser : user.IsAdmin ? Constants.RoleAdmin : Constants.RoleUser;

            List<Claim> claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Role, role),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()) // on peut ajouter l'Id de l'utilisateur en Claim
            };

            SigningCredentials signingCredentials = new SigningCredentials(
                new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_settings.SecretKey!)),
                SecurityAlgorithms.HmacSha256);

            JwtSecurityToken jwt = new JwtSecurityToken(
                issuer: _settings.ValidIssuer,
                audience: _settings.ValidAudience,
                claims: claims,
                signingCredentials: signingCredentials,
                expires: DateTime.Now.AddDays(7)
                );

            return new JwtSecurityTokenHandler().WriteToken(jwt);
        }

        [NonAction]
        private string EncryptPassword(string? password)
        {
            if (string.IsNullOrEmpty(password)) return "";
            return Convert.ToBase64String(Encoding.UTF8.GetBytes(password + _securityPasswordKey));
        }

        //[NonAction]
        //private string DecryptPassword(string? cryptedString)
        //{
        //    if (string.IsNullOrEmpty(cryptedString)) return "";
        //    string decriptedString = Encoding.UTF8.GetString(Convert.FromBase64String(cryptedString));
        //    return decriptedString.Substring(0, decriptedString.Length - _securityPasswordKey.Length);
        //}
    }
}
