// Copyright © 2022 - Theo Debefve
// Examen JUIN 2022

using System.Net;
using System.Web;
using Newtonsoft.Json;

namespace ClassLibrary
{
    public static class ClassApi
    {
        private const string ApiKey = "4be2bcce-2f54-488c-8ff5-8e9b4c96dea8";
        public const int NbrCrypto = 200; // 200 -> 1 API credits

        public static dynamic MakeApiCAll()
        {
            var url = new UriBuilder("https://pro-api.coinmarketcap.com/v1/cryptocurrency/listings/latest");

            var queryString = HttpUtility.ParseQueryString(string.Empty);
            queryString["start"] = "1";
            queryString["limit"] = NbrCrypto.ToString();
            queryString["convert"] = "EUR";

            url.Query = queryString.ToString();

            var client = new WebClient();
            client.Headers.Add("X-CMC_PRO_API_KEY", ApiKey);
            client.Headers.Add("Accepts", "application/json");
            string dataString = client.DownloadString(url.ToString());


            var dobj = JsonConvert.DeserializeObject<dynamic>(dataString);

            return dobj;
        }
    }
}
