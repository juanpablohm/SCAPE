using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using SCAPE.API.ActionsModels;
using SCAPE.Application.DTOs;
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
        private readonly ITokenService _tokenService;
        private readonly IMapper _mapper;
        private readonly IConfiguration _config;

        public UserController(IUserService userService,IMapper mapper,ITokenService tokenService, IConfiguration config)
        {
            _userService = userService;
            _mapper = mapper;
            _tokenService = tokenService;
            _config = config;
        }

        /// <summary>
        /// Method that logs user employees, employers and administrators
        /// </summary>
        /// <param name="data">Object with username and password</param>
        /// <returns>TokenModelDTO with OAuth2 Structure and JSON Web Token</returns>
        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromForm]UserModel data)
        {
            string email = data.username;
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
            TokenModelDTO out_token = _tokenService.getToken(resultLogin,secretKey);
            
            return Ok(out_token);
        }

        /*

        [HttpPost]
        [Authorize(Roles = "Admin")]
        [Route("AddUser")]
        public async Task<IActionResult> addUser(UserModel data)
        {
            string email = data.username;
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
        */
    }
}
