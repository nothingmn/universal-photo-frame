using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoFrame.Common
{
    public interface IBasicWeatherReport
    {
        double CurrentTemperature { get; set; }

        DateTimeOffset LastUpdated { get; set; }

        string Summary { get; set; }
    }
}
