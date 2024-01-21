using CCXT;
using CCXT.NET.Binance.Public;
using System.Diagnostics;

int __step_no = 0;

var _public_api = new PublicApi();

if (__step_no == 0 || __step_no == 1)
{
    await FetchTickerInterval(_public_api);
}
    Console.Out.WriteLine("hit return to exit...");
    Console.ReadLine();

async Task FetchTickerInterval(PublicApi publicApi, int timeSpace = 5000)
{

    while (true)
    {
        Stopwatch sw = Stopwatch.StartNew();
        // Call your CCXT API method here
        var tickers = await publicApi.FetchTickersAsync();
        sw.Stop();
        if (tickers.success)
        {
            var _btcusd_tickers = tickers.result.Where(t => t.symbol.ToUpper().Contains("BTCUSD"));

            foreach (var ticker in _btcusd_tickers)
            {
                Console.Out.WriteLine($"symbol: {ticker.symbol}, closePrice: {ticker.closePrice}");
            }
        }
        else
        {
            Console.Out.WriteLine($"error: {tickers.message}");
        }
        Console.WriteLine("Time taken for tickets: {0}ms", sw.Elapsed.TotalMilliseconds);
        sw = Stopwatch.StartNew();
        var historyCandles = await publicApi.FetchOHLCVsAsync("BTC", "USDT", limits: 10);
        if (historyCandles.success)
        {
            var _btcusd_candles = historyCandles.result;
            foreach (var candle in _btcusd_candles)
            {
                Console.Out.WriteLine($"history Candle: {candle.openPrice}");
            }
        }
        else
        {
            Console.Out.WriteLine($"error: {historyCandles.message}");
        }
        sw.Stop();
        Console.WriteLine("Time taken for history: {0}ms", sw.Elapsed.TotalMilliseconds);



        await Task.Delay(timeSpace); // Delay for timeSpace seconds
    }
}