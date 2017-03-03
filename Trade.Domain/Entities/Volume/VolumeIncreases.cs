using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Trade.Infra.Contract.Entities;

namespace Trade.Domain.Entities.Volume
{
    public class VolumeIncreases : IEnumerable<VolumeIncrease>
    {
        private readonly IEnumerable<VolumeIncrease> _volumes;
        private readonly DateTimeOffset _targetDate;
        private readonly DateTimeOffset?[] _allDate;

        public VolumeIncreases(IEnumerable<YahooVolumeIncreaseRate> volumes, DateTimeOffset targetDate, DateTimeOffset?[] allDate)
        {
            _volumes = volumes.Select(x => new VolumeIncrease(x));
            _targetDate = targetDate;
            _allDate = allDate;
        }

        public string TargetDate => _targetDate.ToString("yyyy-MM-dd");

        public DateTimeOffset? PreviousDate => _allDate.OrderByDescending(x => x).FirstOrDefault(x => x < _targetDate);

        public DateTimeOffset? NextDate => _allDate.OrderBy(x => x).FirstOrDefault(x => _targetDate < x);

        public IEnumerator<VolumeIncrease> GetEnumerator()
        {
            return _volumes.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
