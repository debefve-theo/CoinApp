using System;
using System.Net;
using System.Web;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Newtonsoft.Json;

namespace LibraryCrypto
{
    public class ClassAPI
    {
        private static string API_KEY = "4be2bcce-2f54-488c-8ff5-8e9b4c96dea8";
        private static int NBR_CRYPTO = 200; // 200 -> 1 API credits

        private static List<Crypto> mainCryptoList = new List<Crypto>();

        public static List<Crypto> GetCryptoList()
        {
            try
            {
                dynamic dobj = MakeAPICAll();

                try
                {
                    for (int i = 0; i < NBR_CRYPTO; i++)
                    {
                        Crypto CryptoPlus = new Crypto(
                            (int)dobj["data"][i]["id"],
                            (string)dobj["data"][i]["name"],
                            (string)dobj["data"][i]["symbol"],
                            (double)dobj["data"][i]["quote"]["EUR"]["price"],
                            (double)dobj["data"][i]["quote"]["EUR"]["volume_24h"],
                            (double)dobj["data"][i]["quote"]["EUR"]["percent_change_1h"],
                            (double)dobj["data"][i]["quote"]["EUR"]["percent_change_24h"],
                            (double)dobj["data"][i]["quote"]["EUR"]["percent_change_7d"],
                            (double)dobj["data"][i]["quote"]["EUR"]["market_cap"]
                        );

                        mainCryptoList.Add(CryptoPlus);
                    }
                }
                catch
                {
                    Console.WriteLine("Méthode GetCryptoList : Erreur lors de l'ajout a la liste");
                }
            }
            catch
            {
                Console.WriteLine("Méthode GetCryptoList : Erreur lors de la connection a l'API");
            }

            return mainCryptoList;
        }

        static dynamic MakeAPICAll()
        {
            var URL = new UriBuilder("https://pro-api.coinmarketcap.com/v1/cryptocurrency/listings/latest");

            var queryString = HttpUtility.ParseQueryString(string.Empty);
            queryString["start"] = "1";
            queryString["limit"] = NBR_CRYPTO.ToString();
            queryString["convert"] = "EUR";

            URL.Query = queryString.ToString();

            var client = new WebClient();
            client.Headers.Add("X-CMC_PRO_API_KEY", API_KEY);
            client.Headers.Add("Accepts", "application/json");
            string dataString = client.DownloadString(URL.ToString());


            dynamic dobj = JsonConvert.DeserializeObject<dynamic>(dataString);

            return dobj;
        }
    }
}
