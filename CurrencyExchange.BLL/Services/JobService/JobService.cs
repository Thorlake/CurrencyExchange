namespace CurrencyExchange.BLL.Services.JobService
{
    using System;
    using System.Threading;
    using CurrencyExchange.BLL.Abstractions.Services;
    using CurrencyExchange.BLL.Services.JobService.Jobs;
    using Hangfire;

    public class JobService : IJobService
    {
        /// <summary>
        /// Cron
        /// # ┌───────────── minute (0 - 59)
        /// # │ ┌───────────── hour (0 - 23)
        /// # │ │ ┌───────────── day of the month (1 - 31)
        /// # │ │ │ ┌───────────── month (1 - 12)
        /// # │ │ │ │ ┌───────────── day of the week (0 - 6) (Sunday to Saturday;
        /// # │ │ │ │ │              7 is also Sunday on some systems)
        /// # │ │ │ │ │
        /// # │ │ │ │ │
        /// # * * * * * command to execute.
        /// </summary>
        public void UpdateJobs()
        {
            AddOrUpdateJob<UpdateCurrenciesJob>("0 0 * * *");
        }

        private void AddOrUpdateJob<TTask>(string cronExpression)
            where TTask : IJob
        {
            var jobId = typeof(TTask).Name;
            RecurringJob.AddOrUpdate<TTask>(
                jobId,
                (task) => task.Run(CancellationToken.None),
                cronExpression,
                TimeZoneInfo.Utc);
        }
    }
}
