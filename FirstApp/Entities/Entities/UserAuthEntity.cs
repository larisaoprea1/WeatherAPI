using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class UserAuthEntity:BaseModel
    {
        public string Email { get; set; }
        public byte[] KeyPassword { get; set; }
        public byte[] HashPassword { get; set; }
        public ICollection<WeatherData> WeatherDatas { get; set; }
    }
}
