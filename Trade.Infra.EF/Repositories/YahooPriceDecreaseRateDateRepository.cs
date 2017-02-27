using Microsoft.EntityFrameworkCore;
using Trade.Infra.Contract.Entities;
using Trade.Infra.EF.Repositories.Abstractions;

namespace Trade.Infra.EF.Repositories
{
    public class YahooPriceDecreaseRateDateRepository : RepositoryBase<YahooPriceDecreaseRateDate>
    {
        public YahooPriceDecreaseRateDateRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
