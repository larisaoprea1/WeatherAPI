using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Weather
{
    public class WeatherData
    {
        public string City { get; set; }
        public string Country { get; set; }
        public string Description { get; set; }
        public double Temperature { get; set; }
        public DateTime QueryDateTime { get; set; }

    }
}
