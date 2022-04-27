// Copyright © 2022 - Theo Debefve

using System;
using System.Net;
using System.Web;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;
using Model;
using ViewModel;

namespace ClassLibrary
{
    public static class ClassApi
    {
        private const string ApiKey = "4be2bcce-2f54-488c-8ff5-8e9b4c96dea8";
        private const int NbrCrypto = 200; // 200 -> 1 API credits

        public static CryptoViewModel? CurrentCrypto;

        public static ObservableCollection<CryptoViewModel> Items;


        public static ObservableCollection<CryptoViewModel> GetCryptoList()
        {
            var dobj = MakeApiCAll();

            string codeErreur = dobj["status"]["error_code"];
            string messageErreur = dobj["status"]["error_message"];

            for (var i = 0; i < NbrCrypto; i++)
            {
                CurrentCrypto = new CryptoViewModel(new Crypto()
                {
                    Id = dobj["data"][i]["id"],
                    Name = dobj["data"][i]["name"],
                    Symbol = dobj["data"][i]["symbol"],
                    Price = dobj["data"][i]["quote"]["EUR"]["price"],
                    Volume24H = dobj["data"][i]["quote"]["EUR"]["volume_24h"],
                    Change1H = dobj["data"][i]["quote"]["EUR"]["percent_change_1h"],
                    Change1D = dobj["data"][i]["quote"]["EUR"]["percent_change_24h"],
                    Change1W = dobj["data"][i]["quote"]["EUR"]["percent_change_7d"],
                    Marketcap = dobj["data"][i]["quote"]["EUR"]["market_cap"]
                });

                Items.Add(CurrentCrypto);
            }

            return Items;
        }

        private static dynamic MakeApiCAll()
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
