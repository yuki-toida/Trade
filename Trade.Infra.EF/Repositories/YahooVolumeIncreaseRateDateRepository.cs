using Microsoft.EntityFrameworkCore;
using Trade.Infra.Contract.Models.Entities;
using Trade.Infra.EF.Repositories.Abstractions;

namespace Trade.Infra.EF.Repositories
{
    public class YahooVolumeIncreaseRateDateRepository : RepositoryBase<YahooVolumeIncreaseRateDate>
    {
        public YahooVolumeIncreaseRateDateRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
