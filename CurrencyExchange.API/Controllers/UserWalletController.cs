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

    [Route("users/{userId}/wallets")]
    public class UserWalletController : ApiControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUserWalletService _userWalletService;

        public UserWalletController(
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

        [HttpPost("deposit")]
        public UserWalletResponse Deposit(Guid userId, UserWalletDepositRequest model)
        {
            var args = _mapper.Map<UserWalletDepositArgs>(model);
            args.UserId = userId;
            var userWallet = _userWalletService.Deposit(args);
            return _mapper.Map<UserWalletResponse>(userWallet);
        }

        [HttpPost("withdrawal")]
        public UserWalletResponse Withdrawal(Guid userId, UserWalletWithdrawalRequest model)
        {
            var args = _mapper.Map<UserWalletWithdrawalArgs>(model);
            args.UserId = userId;
            var userWallet = _userWalletService.Withdrawal(args);
            return _mapper.Map<UserWalletResponse>(userWallet);
        }

        [HttpPost("exchange")]
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