namespace CurrencyExchange.BLL.Services.JobService
{
    using System.Threading;

    public interface IJob
    {
        void Run(CancellationToken cancellationToken);
    }
}
