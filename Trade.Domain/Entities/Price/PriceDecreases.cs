using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Trade.Infra.Contract.Entities;

namespace Trade.Domain.Entities.Price
{
    public class PriceDecreases : IEnumerable<PriceDecrease>
    {
        private readonly IEnumerable<PriceDecrease> _prices;
        private readonly DateTime _targetDate;
        private readonly DateTime?[] _allDate;

        public PriceDecreases(IEnumerable<YahooPriceDecreaseRate> prices, DateTime targetDate, DateTime?[] allDate)
        {
            _prices = prices.Select(x => new PriceDecrease(x));
            _targetDate = targetDate;
            _allDate = allDate;
        }

        public string TargetDate => _targetDate.ToString("yyyy-MM-dd");

        public DateTime? PreviousDate => _allDate.OrderByDescending(x => x).FirstOrDefault(x => x < _targetDate);

        public DateTime? NextDate => _allDate.OrderBy(x => x).FirstOrDefault(x => _targetDate < x);

        public IEnumerator<PriceDecrease> GetEnumerator()
        {
            return _prices.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
