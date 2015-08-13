using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotoFrame.Common;

namespace PhotoFrame.Forecastio
{
    public class Forecast : IBasicWeatherReport
    {
        
        private double _currentTemperature;
        private string _summary;
        public float latitude { get; set; }
        public float longitude { get; set; }
        public string timezone { get; set; }
        public int offset { get; set; }
        public Currently currently { get; set; }
        public Minutely minutely { get; set; }
        public Hourly hourly { get; set; }
        public Daily daily { get; set; }
        public Flags flags { get; set; }

        public double CurrentTemperature
        {
            get
            {

                if (currently != null)
                {
                    _currentTemperature = currently.temperature;                    
                }
                else
                {
                    _currentTemperature = 0;
                }
                return _currentTemperature;
            }
            set { _currentTemperature = value; }
        }

        public DateTimeOffset LastUpdated { get; set; }

        public string Summary
        {
            get
            {
                if (currently != null)
                {
                    _summary = currently.summary;
                }
                else
                {
                    _summary = "";
                }
                return _summary;
            }
            set { _summary = value; }
        }
    }


    public class Currently
    {
        public int time { get; set; }
        public string summary { get; set; }
        public string icon { get; set; }
        public int nearestStormDistance { get; set; }
        public int nearestStormBearing { get; set; }
        public int precipIntensity { get; set; }
        public int precipProbability { get; set; }
        public float temperature { get; set; }
        public float apparentTemperature { get; set; }
        public float dewPoint { get; set; }
        public float humidity { get; set; }
        public float windSpeed { get; set; }
        public int windBearing { get; set; }
        public float visibility { get; set; }
        public float cloudCover { get; set; }
        public float pressure { get; set; }
        public float ozone { get; set; }
    }

    public class Minutely
    {
        public string summary { get; set; }
        public string icon { get; set; }
        public Datum[] data { get; set; }
    }

    public class Datum
    {
        public int time { get; set; }
        public int precipIntensity { get; set; }
        public int precipProbability { get; set; }
    }

    public class Hourly
    {
        public string summary { get; set; }
        public string icon { get; set; }
        public Datum1[] data { get; set; }
    }

    public class Datum1
    {
        public int time { get; set; }
        public string summary { get; set; }
        public string icon { get; set; }
        public float precipIntensity { get; set; }
        public float precipProbability { get; set; }
        public float temperature { get; set; }
        public float apparentTemperature { get; set; }
        public float dewPoint { get; set; }
        public float humidity { get; set; }
        public float windSpeed { get; set; }
        public int windBearing { get; set; }
        public float visibility { get; set; }
        public float cloudCover { get; set; }
        public float pressure { get; set; }
        public float ozone { get; set; }
        public string precipType { get; set; }
    }

    public class Daily
    {
        public string summary { get; set; }
        public string icon { get; set; }
        public Datum2[] data { get; set; }
    }

    public class Datum2
    {
        public int time { get; set; }
        public string summary { get; set; }
        public string icon { get; set; }
        public int sunriseTime { get; set; }
        public int sunsetTime { get; set; }
        public float moonPhase { get; set; }
        public float precipIntensity { get; set; }
        public float precipIntensityMax { get; set; }
        public float precipProbability { get; set; }
        public float temperatureMin { get; set; }
        public int temperatureMinTime { get; set; }
        public float temperatureMax { get; set; }
        public int temperatureMaxTime { get; set; }
        public float apparentTemperatureMin { get; set; }
        public int apparentTemperatureMinTime { get; set; }
        public float apparentTemperatureMax { get; set; }
        public int apparentTemperatureMaxTime { get; set; }
        public float dewPoint { get; set; }
        public float humidity { get; set; }
        public float windSpeed { get; set; }
        public int windBearing { get; set; }
        public float visibility { get; set; }
        public float cloudCover { get; set; }
        public float pressure { get; set; }
        public float ozone { get; set; }
        public int precipIntensityMaxTime { get; set; }
        public string precipType { get; set; }
    }

    public class Flags
    {
        public string[] sources { get; set; }
        public string[] darkskystations { get; set; }
        public string[] isdstations { get; set; }
        public string[] madisstations { get; set; }
        public string[] lampstations { get; set; }
        public string units { get; set; }
    }

}
