namespace CurrencyExchange.BLL.Services
{
    using System;
    using CurrencyExchange.DAL;
    using CurrencyExchange.Model.Abstractions;

    public class WalletService : IWalletService
    {
        private readonly IDbContext _context;

        public WalletService(
           IDbContext context)
        {
            _context = context;
        }

        public IWallet GetById(Guid id)
        {
            return _context.Wallets.GetById(id);
        }

        public void UpdateAmount(Guid id)
        {
            // Method intentionally left empty.
        }
    }
}
