namespace CurrencyExchange.BLL.Services.JobService.Jobs
{
    using System;
    using System.Threading;

    public abstract class BaseJob : IJob
    {
        private CancellationToken _cancellationToken;

        public void Run(CancellationToken cancellationToken)
        {
            try
            {
                _cancellationToken = cancellationToken;
                RunSafe();
            }
            catch (Exception)
            {
                // catch
            }
        }

        protected abstract void RunSafe();

        protected void ThrowIfCancellationRequested()
        {
            _cancellationToken.ThrowIfCancellationRequested();
        }
    }
}
