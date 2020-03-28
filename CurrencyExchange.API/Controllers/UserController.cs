namespace CurrencyExchange.API.Controllers
{
    using System;
    using System.Collections.Generic;
    using AutoMapper;
    using CurrencyExchange.API.Dto.Requests.User;
    using CurrencyExchange.API.Dto.Responses.User;
    using CurrencyExchange.BLL.Abstractions.Services.Args;
    using CurrencyExchange.BLL.Services;
    using Microsoft.AspNetCore.Mvc;

    public class UserController : ApiControllerBase
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
        public UserResponse Get(Guid id)
        {
            var user = _userService.GetById(id);
            return _mapper.Map<UserResponse>(user);
        }

        [HttpPost]
        public UserResponse Create(CreateUserRequest model)
        {
            var args = _mapper.Map<CreateUserArgs>(model);
            var user = _userService.Add(args);
            return _mapper.Map<UserResponse>(user);
        }

        [HttpPut("{id}")]
        public UserResponse Update(Guid id, [FromBody] string value)
        {
            return null;
        }

        [HttpDelete("{id}")]
        public NoContentResult Delete(Guid id)
        {
            _userService.Remove(id);
            return NoContent();
        }
    }
}
