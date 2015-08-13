using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoFrame.Common
{
    public interface IWeatherProvider
    {

        Task<IBasicWeatherReport> GetWeatherReport(string location);

    }
}
