using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using SCAPE.API.ActionsModels;
using SCAPE.Application.Interfaces;
using SCAPE.Domain.Entities;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace SCAPE.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        private readonly IConfiguration _config;

        public UserController(IUserService userService,IMapper mapper,IConfiguration config)
        {
            _userService = userService;
            _mapper = mapper;
            _config = config;
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login(UserModel data)
        {
            string email = data.email;
            string password = data.password;

            User resultLogin = null;
            try
            {
                resultLogin = await _userService.login(email, password);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            //Create JSON Web Token

            var secretKey = _config.GetValue<string>("SecretKey");
            var key = Encoding.ASCII.GetBytes(secretKey);

            var claims = new ClaimsIdentity();
            claims.AddClaim(new Claim(ClaimTypes.Email, email));
            claims.AddClaim(new Claim("role", resultLogin.Role));

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = claims,
                Expires = DateTime.UtcNow.AddHours(4),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var createdToken = tokenHandler.CreateToken(tokenDescriptor);

            string bearer_token = tokenHandler.WriteToken(createdToken);
            return Ok(bearer_token);
        }

        [HttpPost]
        [Authorize]
        [Route("AddUser")]
        public async Task<IActionResult> addUser(UserModel data)
        {
            string email = data.email;
            string password = data.password;
            string role = data.role;

            bool resultInsert = true;
            try
            {
                resultInsert = await _userService.addUser(email, password, role);
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok(resultInsert);
        }
    }
}
