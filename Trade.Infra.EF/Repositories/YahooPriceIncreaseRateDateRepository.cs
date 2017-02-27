using Microsoft.EntityFrameworkCore;
using Trade.Infra.Contract.Entities;
using Trade.Infra.EF.Repositories.Abstractions;

namespace Trade.Infra.EF.Repositories
{
    public class YahooPriceIncreaseRateDateRepository : RepositoryBase<YahooPriceIncreaseRateDate>
    {
        public YahooPriceIncreaseRateDateRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
