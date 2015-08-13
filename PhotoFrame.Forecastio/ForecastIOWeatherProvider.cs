using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using PhotoFrame.Common;

namespace PhotoFrame.Forecastio
{
    public class ForecastIOWeatherProvider : IWeatherProvider
    {
        private Forecast _last = null;
        private readonly string _apiKey;
        private readonly string _units;
        HttpClient _client = new HttpClient();
        public ForecastIOWeatherProvider(string apiKey, string units = "ca")
        {
            _apiKey = apiKey;
            _units = units;
        }

        public async Task<IBasicWeatherReport> GetWeatherReport(string location)
        {
            if (_last != null)
            {
                var diff = System.DateTimeOffset.UtcNow - _last.LastUpdated;
                if (diff.Hours > 1) _last = null;
            }

            if (_last == null)
            {

                var url = string.Format("https://api.forecast.io/forecast/{0}/{1}?units={2}", _apiKey, location, _units);
                var json = await _client.GetStringAsync(url);
                _last = Newtonsoft.Json.JsonConvert.DeserializeObject<Forecast>(json);
                _last.LastUpdated = DateTimeOffset.UtcNow;
            }
            return _last;
        }
    }
}
