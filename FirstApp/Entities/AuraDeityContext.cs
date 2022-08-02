using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class AuraDeityContext : DbContext
    {
        public AuraDeityContext(DbContextOptions<AuraDeityContext> dbContextOptions)
            : base(dbContextOptions)
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
            AppContext.SetSwitch("Npgsql.DisableDateTimeInfinityConversions", true);

        }
        public DbSet<UserAuthEntity> UserAuths { get; set; }
        public DbSet<WeatherData> WeatherDatas { get; set; }
    }
}
