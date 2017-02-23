using Microsoft.EntityFrameworkCore;
using Trade.Infra.Contract.Contexts.Data;
using Trade.Infra.Contract.Models.Entities;
using Trade.Infra.Contract.Repositories;
using Trade.Infra.EF.Repositories;

namespace Trade.Infra.EF.DataContexts
{
    public class DataContexts : IDataContexts
    {
        public DataContexts(DbContext dbContext)
        {
            _dbContext = dbContext;

            YahooVolumeIncreaseRateDateRepository = new YahooVolumeIncreaseRateDateRepository(_dbContext);
            YahooVolumeIncreaseRateRepository = new YahooVolumeIncreaseRateRepository(_dbContext);
            YahooPriceIncreaseRateDateRepository = new YahooPriceIncreaseRateDateRepository(_dbContext);
            YahooPriceIncreaseRateRepository = new YahooPriceIncreaseRateRepository(_dbContext);
        }

        private readonly DbContext _dbContext;

        public IRepository<YahooVolumeIncreaseRateDate> YahooVolumeIncreaseRateDateRepository { get; }
        public IRepository<YahooVolumeIncreaseRate> YahooVolumeIncreaseRateRepository { get; }
        public IRepository<YahooPriceIncreaseRateDate> YahooPriceIncreaseRateDateRepository { get; }
        public IRepository<YahooPriceIncreaseRate> YahooPriceIncreaseRateRepository { get; }

        public int SaveChanges()
        {
            return _dbContext.SaveChanges();
        }
    }
}
