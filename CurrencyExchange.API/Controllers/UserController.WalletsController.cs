namespace CurrencyExchange.API.Controllers
{
    using System;
    using System.Collections.Generic;
    using AutoMapper;
    using CurrencyExchange.API.Dto.Requests.User;
    using CurrencyExchange.API.Dto.Responses.User;
    using CurrencyExchange.BLL.Abstractions.Services;
    using CurrencyExchange.BLL.Abstractions.Services.Args;
    using Microsoft.AspNetCore.Mvc;

    public partial class UserController
    {
        [Route("users/{userId}/wallets")]
        public class UserWalletsController : ApiControllerBase
        {
            private readonly IMapper _mapper;
            private readonly IUserWalletService _userWalletService;

            public UserWalletsController(
                IMapper mapper,
                IUserWalletService userWalletService)
            {
                _userWalletService = userWalletService;
                _mapper = mapper;
            }

            [HttpGet]
            public IEnumerable<UserWalletResponse> Get(Guid userId)
            {
                var userWallets = _userWalletService.Get(userId);
                return _mapper.MapMany<UserWalletResponse>(userWallets);
            }

            [HttpGet("{id}")]
            public UserWalletResponse GetBy(Guid id)
            {
                var user = _userWalletService.GetBy(id);
                return _mapper.Map<UserWalletResponse>(user);
            }

            [HttpPost("{id}/deposit")]
            public IActionResult Deposit(Guid userId, UserWalletWithdrawalRequest model)
            {
                var args = _mapper.Map<UserWalletDepositArgs>(model);
                args.UserId = userId;
                _userWalletService.Deposit(args);
                return Ok();
            }

            [HttpPost("{id}/withdrawal")]
            public IActionResult Withdrawal(Guid userId, UserWalletWithdrawalArgs model)
            {
                var args = _mapper.Map<UserWalletWithdrawalArgs>(model);
                args.UserId = userId;
                _userWalletService.Withdrawal(args);
                return Ok();
            }

            [HttpPost("{id}/exchange")]
            public IActionResult Exchange(Guid userId, UserWalletExchangeRequest model)
            {
                var args = _mapper.Map<UserWalletExchangeArgs>(model);
                args.UserId = userId;
                _userWalletService.Exchange(args);
                return Ok();
            }

            [HttpDelete("{id}")]
            public NoContentResult Delete(Guid id)
            {
                _userWalletService.Remove(id);
                return NoContent();
            }
        }
    }
}