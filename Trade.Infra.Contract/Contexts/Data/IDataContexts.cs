using Trade.Infra.Contract.Entities;
using Trade.Infra.Contract.Repositories;

namespace Trade.Infra.Contract.Contexts.Data
{
    public interface IDataContexts
    {
        IRepository<YahooVolumeIncreaseRateDate> YahooVolumeIncreaseRateDateRepository { get; }
        IRepository<YahooVolumeIncreaseRate> YahooVolumeIncreaseRateRepository { get; }
        IRepository<YahooPriceIncreaseRateDate> YahooPriceIncreaseRateDateRepository { get; }
        IRepository<YahooPriceIncreaseRate> YahooPriceIncreaseRateRepository { get; }
        IRepository<YahooPriceDecreaseRateDate> YahooPriceDecreaseRateDateRepository { get; }
        IRepository<YahooPriceDecreaseRate> YahooPriceDecreaseRateRepository { get; }

        int SaveChanges();
    }
}
