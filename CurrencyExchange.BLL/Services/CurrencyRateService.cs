namespace CurrencyExchange.BLL.Services
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http;
    using System.Xml;
    using System.Xml.Linq;
    using CurrencyExchange.BLL.Abstractions;
    using CurrencyExchange.BLL.Abstractions.Services;

    public class CurrencyRateService : ICurrencyRateService
    {
#pragma warning disable S1075 // URIs should not be hardcoded
        private const string CurrencyRateUrl = "https://www.ecb.europa.eu/stats/eurofxref/eurofxref-daily.xml";
#pragma warning restore S1075 // URIs should not be hardcoded

        // https://aspnetmonsters.com/2016/08/2016-08-27-httpclientwrong/
        private static HttpClient httpClient = new HttpClient();

        public IReadOnlyCollection<ICurrencyRate> Get()
        {
            var currencies = new List<ICurrencyRate>();

            var responseMessage = httpClient.GetAsync(CurrencyRateUrl).Result;
            using (var stream = responseMessage.Content.ReadAsStreamAsync().Result)
            {
                var xmlDocument = XDocument.Load(stream);
                foreach (XElement node in xmlDocument
                    .Descendants()
                    .Where(xelement => xelement.Name.LocalName == "Cube")
                    .Where(xelement => xelement.Attribute("currency") != null))
                {
                    var currency = node.Attribute("currency").Value;
                    var rate = decimal.Parse(node.Attribute("rate").Value);
                    currencies.Add(new CurrencyRate
                    {
                        Code = currency,
                        Rate = rate
                    });
                }
            }

            return currencies;
        }

        private class CurrencyRate : ICurrencyRate
        {
            public string Code { get; set; }
            public decimal Rate { get; set; }
        }
    }
}
