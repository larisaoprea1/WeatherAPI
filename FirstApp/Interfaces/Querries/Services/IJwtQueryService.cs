using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.Querries.Services
{
    public interface IJwtQueryService
    {
        string GetJwtToken(string email, long id);
    }
}
