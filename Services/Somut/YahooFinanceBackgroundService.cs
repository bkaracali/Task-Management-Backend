using Microsoft.Extensions.Hosting;
using Services.Soyut;
using System;
using System.Threading;
using System.Threading.Tasks;
using YahooFinanceApi;

public class YahooFinanceBackgroundService : BackgroundService
{
    protected override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        throw new NotImplementedException();
    }
}
