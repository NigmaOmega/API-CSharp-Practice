using ApiAutomationTest.Test;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiAutomationTest
{
   public static class ApiCallingCenter
    {
        public static IRestResponse GetListCoins() { 
            return ApiRest.Call(Method.GET, CoinPaprikaUrl.Coins);
        }

        public static IRestResponse GetCoinById(string coinId)
        {
            Dictionary<string, object> pathParameter = new Dictionary<string, object>();
            pathParameter.Add("coin_id", coinId);

            return ApiRest.Call(RestSharp.Method.GET, CoinPaprikaUrl.CoinById,null,null,null, pathParameter);
        }

        public static IRestResponse GetTwitterTimelineForCoin(string coinId)
        {
            Dictionary<string, object> pathParameter = new Dictionary<string, object>();
            pathParameter.Add("coin_id", coinId);

            return ApiRest.Call(RestSharp.Method.GET, CoinPaprikaUrl.TwitterTimelineCoin, null, null, null, pathParameter);
        }

        public static IRestResponse GetCoinEventsByCoinId(string coinId)
        {
            Dictionary<string, object> pathParameter = new Dictionary<string, object>();
            pathParameter.Add("coin_id", coinId);

            return ApiRest.Call(RestSharp.Method.GET, CoinPaprikaUrl.CoinEventsById, null, null, null, pathParameter);
        }

        public static IRestResponse GetExchangesByCoinId(string coinId)
        {
            Dictionary<string, object> pathParameter = new Dictionary<string, object>();
            pathParameter.Add("coin_id", coinId);

            return ApiRest.Call(RestSharp.Method.GET, CoinPaprikaUrl.ExchangesCoinById, null, null, null, pathParameter);
        }

        public static IRestResponse GetMarketsByCoinId(string coinId)
        {
            Dictionary<string, object> pathParameter = new Dictionary<string, object>();
            pathParameter.Add("coin_id", coinId);

            return ApiRest.Call(RestSharp.Method.GET, CoinPaprikaUrl.MarketsByCoinId, null, null, null, pathParameter);
        }

        public static IRestResponse GetOhlcForLastFullDay(string coinId)
        {
            Dictionary<string, object> pathParameter = new Dictionary<string, object>();
            pathParameter.Add("coin_id", coinId);

            return ApiRest.Call(RestSharp.Method.GET, CoinPaprikaUrl.OhlcForLastFullDay, null, null, null, pathParameter);
        }

        public static IRestResponse GetHistoricalOhlc(string coinId, Dictionary<string,object> parameter)
        {
            Dictionary<string, object> pathParameter = new Dictionary<string, object>();
            pathParameter.Add("coin_id", coinId);

            return ApiRest.Call(RestSharp.Method.GET, CoinPaprikaUrl.HistoricalOhlc, null, null, parameter, pathParameter);
        }

        public static IRestResponse GetTodayOhlc(string coinId, Dictionary<string, Object> parameters)
        {
            Dictionary<string, object> pathParameter = new Dictionary<string, object>();
            pathParameter.Add("coin_id", coinId);

            return ApiRest.Call(RestSharp.Method.GET, CoinPaprikaUrl.TodayOhlc, null, null, parameters, pathParameter);
        }

        public static IRestResponse GetListContractsPlatforms()
        {
            return ApiRest.Call(RestSharp.Method.GET, CoinPaprikaUrl.ListContractsPlatforms);
        }

        public static IRestResponse GetAllContractAddressessForPlatform(string platformId = "",string contractAddress = "", Dictionary<string, object> parameter = null)
        {
            Dictionary<string, object> pathParameter = new Dictionary<string, object>();
            pathParameter.Add("platform_id", platformId);
            pathParameter.Add("contract_address", contractAddress);

            return ApiRest.Call(RestSharp.Method.GET, CoinPaprikaUrl.ContractAddresses, null, null, parameter, pathParameter);
        }

           public static IRestResponse RedirectToTickerByContractAddress(string platformId = "",string contractAddress = "", Dictionary<string, object> parameter = null)
        {
            Dictionary<string, object> pathParameter = new Dictionary<string, object>();
            pathParameter.Add("platform_id", platformId);
            pathParameter.Add("contract_address", contractAddress);

            return ApiRest.Call(RestSharp.Method.GET, CoinPaprikaUrl.RedirectToTickerByContractAddress, null, null, parameter, pathParameter);
        }

          public static IRestResponse RedirectToTickerHistorical(string platformId = "",string contractAddress = "", Dictionary<string, object> parameter = null)
        {
            Dictionary<string, object> pathParameter = new Dictionary<string, object>();
            pathParameter.Add("platform_id", platformId);
            pathParameter.Add("contract_address", contractAddress);

            return ApiRest.Call(RestSharp.Method.GET, CoinPaprikaUrl.RedirectToTickerHistorical, null, null, parameter, pathParameter);
        }



        public static IRestResponse GetListEchanges(Dictionary<string, Object> parameters = null)
        {
            return ApiRest.Call(RestSharp.Method.GET, CoinPaprikaUrl.Exchanges,null,null, parameters);
        }

        public static IRestResponse GetExchangeById(string exchangeId, Dictionary<string, Object> parameters = null)
        {
            Dictionary<string, object> pathParameter = new Dictionary<string, object>();
            pathParameter.Add("exchange_id", exchangeId);

            return ApiRest.Call(RestSharp.Method.GET, CoinPaprikaUrl.ExchangesById, null, null, parameters, pathParameter);
        }

        public static IRestResponse GetMarketsByExchangeId(string exchangeId, Dictionary<string, Object> parameters = null)
        {
            Dictionary<string, object> pathParameter = new Dictionary<string, object>();
            pathParameter.Add("exchange_id", exchangeId);

            return ApiRest.Call(RestSharp.Method.GET, CoinPaprikaUrl.MarketsByExchangeId, null, null, parameters, pathParameter);
        }

        public static IRestResponse GetGlobalInformation()
        {
            return ApiRest.Call(RestSharp.Method.GET, CoinPaprikaUrl.Global);
        }

        public static IRestResponse GetPeopleById(string personId)
        {
            Dictionary<string, object> pathParameter = new Dictionary<string, object>();
            pathParameter.Add("person_id", personId);

            return ApiRest.Call(RestSharp.Method.GET, CoinPaprikaUrl.PeopleById,null,null,null,pathParameter);
        }

        public static IRestResponse GetListTags(Dictionary<string,object> parameters)
        {
            return ApiRest.Call(RestSharp.Method.GET, CoinPaprikaUrl.ListTags, null, null, parameters);
        }

        public static IRestResponse GetTickersForAllCoins(Dictionary<string, object> parameters)
        {
            return ApiRest.Call(RestSharp.Method.GET, CoinPaprikaUrl.Tickers, null, null, parameters);
        }

        public static IRestResponse GetTickerInformationForSpecificCoin(string coinId, Dictionary<string, object> parameters = null)
        {
            Dictionary<string, object> pathParameter = new Dictionary<string, object>();
            pathParameter.Add("coin_id", coinId);

            return ApiRest.Call(RestSharp.Method.GET, CoinPaprikaUrl.TickerInformation, null, null, parameters, pathParameter);
        }

        public static IRestResponse GetHistoricalTickersForSpecificCoin(string coinId, Dictionary<string, object> parameters = null)
        {
            Dictionary<string, object> pathParameter = new Dictionary<string, object>();
            pathParameter.Add("coin_id", coinId);

            return ApiRest.Call(RestSharp.Method.GET, CoinPaprikaUrl.HistoricalTicker, null, null, parameters, pathParameter);
        }

        public static IRestResponse Search(Dictionary<string, object> parameters = null)
        {
            return ApiRest.Call(RestSharp.Method.GET, CoinPaprikaUrl.Search, null, null, parameters);
        }

        public static IRestResponse GetPriceConverter(Dictionary<string, object> parameters = null)
        {
            return ApiRest.Call(RestSharp.Method.GET, CoinPaprikaUrl.PriceConverter, null, null, parameters);
        }

        









    }
}
