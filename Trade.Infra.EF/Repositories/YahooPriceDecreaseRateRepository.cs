using Microsoft.EntityFrameworkCore;
using Trade.Infra.Contract.Entities;
using Trade.Infra.EF.Repositories.Abstractions;

namespace Trade.Infra.EF.Repositories
{
    public class YahooPriceDecreaseRateRepository : RepositoryBase<YahooPriceDecreaseRate>
    {
        public YahooPriceDecreaseRateRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
