using Microsoft.EntityFrameworkCore;
using Trade.Infra.Contract.Models.Entities;
using Trade.Infra.EF.Repositories.Abstractions;

namespace Trade.Infra.EF.Repositories
{
    public class YahooPriceIncreaseRateRepository : RepositoryBase<YahooPriceIncreaseRate>
    {
        public YahooPriceIncreaseRateRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
