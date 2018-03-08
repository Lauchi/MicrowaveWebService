﻿using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace GeneratedWebService.Controllers
{
    [Route("api/users")]
    public class UserController : Controller
    {
        private readonly IUserCommandHandler _commandHandler;

        public UserController(IUserCommandHandler commandHandler)
        {
            _commandHandler = commandHandler;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            return await _commandHandler.GetUser(id);
        }

        [HttpGet()]
        public async Task<IActionResult> Get()
        {
            return await _commandHandler.GetUsers();
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserCommand createUserCommand)
        {
            return await _commandHandler.CreateUser(createUserCommand);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUserName(Guid id, [FromBody] UpdateUserNameCommand updateUserNameCommand)
        {
            return await _commandHandler.UpdateUserName(id, updateUserNameCommand);
        }
    }
}