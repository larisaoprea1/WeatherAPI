using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class WeatherData : BaseModel
    {
        public string City { get; set; }
        public string Country { get; set; }
        public string Description { get; set; }
        public double Temperature { get; set; }
        public DateTime QueryDateTime { get; set; }

        [ForeignKey("UserAuthEntity")]
        public long UserAuthId { get; set; }
        public UserAuthEntity UserAuthEntity { get; set; }


    }
}
