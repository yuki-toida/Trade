using System.Linq;
using Trade.Domain.Entities.Volume;
using Trade.Domain.ValueObjects;
using Trade.Infra.Core.Extensions;
using Trade.UI.Web.Models.ViewModels.Shared;

namespace Trade.UI.Web.Models.ViewModels.Volume
{
    public class VolumeIncreaseViewModel : NavigationViewModel
    {
        public VolumeIncreaseViewModel(VolumeIncreases volumeIncreases)
        {
            Title = CalendarEventType.VolumeIncrease.GetValue<string>();
            EventType = CalendarEventType.VolumeIncrease;
            TargetDate = volumeIncreases.TargetDate;
            PreviousDate = volumeIncreases.PreviousDate;
            NextDate = volumeIncreases.NextDate;
            Items = volumeIncreases.Select(x => new VolumeIncreaseItemViewModel(x)).ToArray();
        }

        /// <summary>
        /// 出来高アイテム
        /// </summary>
        public VolumeIncreaseItemViewModel[] Items { get; }
    }
}
