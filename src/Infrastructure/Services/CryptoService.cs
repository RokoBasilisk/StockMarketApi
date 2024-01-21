using CCXT.NET.Shared.Coin.Public;
using SharedDomain.Models;
using SharedDomain.Models.Interface;
using System;

public class CryptoService
{
	public PublicApi _publicApi { get; set; }
	public string _baseName { get; }
	public string _quoteName { get; }

    int __step_no = 0;

	private static readonly int maxRequestCounter = 3;

    public CryptoService(PublicApi publicApi, string baseName = "BTC", string quoteName = "USDT")
	{
        _publicApi = publicApi;
        _baseName = baseName;
        _quoteName = quoteName;
    }

	public async Task<IApiBase> GetOHLCVsAsync()
	{
		var remainCounter = maxRequestCounter;
        var exceptions = new List<Exception>();
        do
        {
            try
            {
                remainCounter--;
                var historyCandles = await _publicApi.FetchOHLCVsAsync(_baseName, _quoteName);
                if (!historyCandles.success)
                {
                    throw new Exception($"Cannot get {_baseName} history");
                }
                return new ApiSuccessResponse<List<IOHLCVItem>>(historyCandles.result);
            }
            catch (Exception e)
            {
                exceptions.Add(e);
            }
        } while (remainCounter > 0);

        throw new AggregateException(exceptions);
    }

}
