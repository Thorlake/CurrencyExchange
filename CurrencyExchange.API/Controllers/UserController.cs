﻿namespace CurrencyExchange.API.Controllers
{
    using System;
    using System.Collections.Generic;
    using AutoMapper;
    using CurrencyExchange.API.Dto.Requests.User;
    using CurrencyExchange.API.Dto.Responses.User;
    using CurrencyExchange.BLL.Abstractions.Services;
    using CurrencyExchange.BLL.Abstractions.Services.Args;
    using Microsoft.AspNetCore.Mvc;

    [Route("users")]
    public partial class UserController : ApiControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUserService _userService;

        public UserController(
            IMapper mapper,
            IUserService userService)
        {
            _userService = userService;
            _mapper = mapper;
        }

        [HttpGet]
        public IEnumerable<UserResponse> Get()
        {
            var users = _userService.Get();
            return _mapper.MapMany<UserResponse>(users);
        }

        [HttpGet("{id}")]
        public UserResponse GetBy(Guid id)
        {
            var user = _userService.GetBy(id);
            return _mapper.Map<UserResponse>(user);
        }

        [HttpPost]
        public UserResponse Create(UserCreateRequest model)
        {
            var args = _mapper.Map<UserCreateArgs>(model);
            var user = _userService.Add(args);
            return _mapper.Map<UserResponse>(user);
        }

        [HttpDelete("{id}")]
        public NoContentResult Delete(Guid id)
        {
            _userService.Remove(id);
            return NoContent();
        }
    }
}
