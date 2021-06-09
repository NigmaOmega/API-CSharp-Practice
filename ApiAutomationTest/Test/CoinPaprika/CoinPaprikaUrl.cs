namespace ApiAutomationTest.Test
{
    static class CoinPaprikaUrl
    {
        public static string BaseUrl { get; } = "https://api.coinpaprika.com/v1";
        public static string Global { get; } = BaseUrl + "/global";
        public static string Coins { get; } = BaseUrl + "/coins";
        public static string CoinById { get; } = BaseUrl + "/coins/{coin_id}";
        public static string TwitterTimelineCoin { get; } = BaseUrl + "/coins/{coin_id}/twitter";
        public static string CoinEventsById { get; } = BaseUrl + "/coins/{coin_id}/events";
        public static string ExchangesCoinById { get; } = BaseUrl + "/coins/{coin_id}/exchanges";
        public static string MarketsByCoinId { get; } = BaseUrl + "/coins/{coin_id}/markets";
        public static string OhlcForLastFullDay { get; } = BaseUrl + "/coins/{coin_id}/ohlcv/latest/";
        public static string HistoricalOhlc { get; } = BaseUrl + "/coins/{coin_id}/ohlcv/historical";
        public static string TodayOhlc { get; } = BaseUrl + "/coins/{coin_id}/ohlcv/today/";
        public static string PeopleById { get; } = BaseUrl + "/people/{person_id}";
        public static string TagById { get; } = BaseUrl + "/tags/{tag_id}";
        public static string ListTags { get; } = BaseUrl + "/tags";
        public static string Tickers { get; } = BaseUrl + "/tickers";
        public static string TickerInformation { get; } = BaseUrl + "/tickers/{coin_id}";
        public static string HistoricalTicker { get; } = BaseUrl + "/tickers/{coin_id}/historical";
        public static string Exchanges { get; } = BaseUrl + "/exchanges";
        public static string ExchangesById { get; } = BaseUrl + "/exchanges/{exchange_id}";
        public static string MarketsByExchangeId { get; } = BaseUrl + "/exchanges/{exchange_id}/markets";
        public static string Search { get; } = BaseUrl + "/search";
        public static string PriceConverter { get; } = BaseUrl + "/price-converter";
        public static string ListContractsPlatforms { get; } = BaseUrl + "/contracts";
        public static string ContractAddresses { get; } = BaseUrl + "/contracts/{platform_id}";
        public static string RedirectToTickerHistorical { get; } = BaseUrl + "/contracts/{platform_id}/{contract_address}/historical";
        public static string RedirectToTickerByContractAddress { get; } = BaseUrl + "/contracts/{platform_id}/{contract_address}";
    }
}
