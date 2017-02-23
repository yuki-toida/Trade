using Microsoft.EntityFrameworkCore;
using Trade.Infra.Contract.Models.Entities;
using Trade.Infra.EF.Repositories.Abstractions;

namespace Trade.Infra.EF.Repositories
{
    public class YahooVolumeIncreaseRateRepository : RepositoryBase<YahooVolumeIncreaseRate>
    {
        public YahooVolumeIncreaseRateRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
