namespace CurrencyExchange.BLL.Services
{
    using System;
    using System.Collections.Generic;
    using AutoMapper;
    using CurrencyExchange.BLL.Abstractions.Services;
    using CurrencyExchange.BLL.Abstractions.Services.Args;
    using CurrencyExchange.DAL;
    using CurrencyExchange.Model.Abstractions;
    using CurrencyExchange.Model.Entities;

    public class UserWalletService : IUserWalletService
    {
        private readonly IDbContext _context;
        private readonly IMapper _mapper;

        public UserWalletService(
           IDbContext context,
           IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // queries

        public IReadOnlyCollection<IUserWallet> Get(Guid userId)
        {
            // TODO: fix you mean by user probably?
            return _context.UserWallets.Get();
        }

        public IUserWallet GetBy(Guid id)
        {
            return _context.UserWallets.GetBy(id);
        }

        // commands
        public IUserWallet Deposit(UserWalletDepositArgs args)
        {
            if (args.Amount < 0)
            {
                throw new Exception("Amount of money has to be greater than 0");
            }

            // We do not want to create user wallet with currency that system does not know
            var currency = _context.Currencies.GetBy(args.CurrencyId);
            if (currency == null)
            {
                throw new ArgumentException($"Currency {args.CurrencyId} does not exist");
            }

            var userWallet = _context.UserWallets.Get(args.UserId, args.CurrencyId);
            if (userWallet == null)
            {
                var dbUserWallet = new UserWallet
                {
                    UserId = args.UserId,
                    CurrencyId = args.CurrencyId,
                    Balance = args.Amount
                };
                userWallet = _context.UserWallets.Add(dbUserWallet);
            }
            else
            {
                userWallet.Balance += args.Amount;
                _context.UserWallets.Update(userWallet);
            }

            return userWallet;
        }

        public IUserWallet Withdrawal(UserWalletWithdrawalArgs args)
        {
            if (args.Amount <= 0)
            {
                throw new ArgumentException("Amount of money has to be greater than 0");
            }

            var userWallet = _context.UserWallets.Get(args.UserId, args.CurrencyId);
            if (userWallet == null)
            {
                throw new ArgumentException($"Currency {args.CurrencyId} does not exist");
            }
            if (userWallet.Balance < args.Amount)
            {
                throw new ArgumentException($"Not enough money in your wallet. Available balance: {userWallet.Balance}");
            }

            userWallet.Balance -= args.Amount;
            _context.UserWallets.Update(userWallet);
            return userWallet;
        }

        public void Exchange(UserWalletExchangeArgs args)
        {
            if (args.Amount < 0)
            {
                throw new Exception("Сумма должна быть больше нуля");
            }

            var fromCurrency = _context.Currencies.GetBy(args.FromCurrencyId);
            if (fromCurrency == null)
            {
                throw new ArgumentException($"Currency {args.FromCurrencyId} does not exist");
            }

            var toCurrency = _context.Currencies.GetBy(args.ToCurrencyId);
            if (toCurrency == null)
            {
                throw new ArgumentException($"Currency {args.ToCurrencyId} does not exist");
            }

            using (var transaction = _context.BeginTransaction())
            {
                var convertAmount = args.Amount * fromCurrency.Rate / toCurrency.Rate;

                var withdrawalArgs = _mapper.Map<UserWalletWithdrawalArgs>(args);
                withdrawalArgs.Amount = convertAmount;
                Withdrawal(withdrawalArgs);

                var depositArgs = _mapper.Map<UserWalletDepositArgs>(args);
                depositArgs.Amount = convertAmount;
                Deposit(depositArgs);

                transaction.Commit();
            }
        }

        public void Remove(Guid id) => _context.UserWallets.Remove(id);
    }
}
