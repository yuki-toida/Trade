using Trade.Infra.Contract.Models.Entities;
using Trade.Infra.Contract.Repositories;

namespace Trade.Infra.Contract.Contexts.Data
{
    public interface IDataContexts
    {
        IRepository<YahooVolumeIncreaseRateDate> YahooVolumeIncreaseRateDateRepository { get; }
        IRepository<YahooVolumeIncreaseRate> YahooVolumeIncreaseRateRepository { get; }
        IRepository<YahooPriceIncreaseRateDate> YahooPriceIncreaseRateDateRepository { get; }
        IRepository<YahooPriceIncreaseRate> YahooPriceIncreaseRateRepository { get; }

        int SaveChanges();
    }
}
