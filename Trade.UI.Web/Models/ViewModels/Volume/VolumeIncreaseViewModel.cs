using System.Linq;
using Trade.Domain.Entities.Volume;
using Trade.Domain.Services.Utilities;
using Trade.Domain.ValueObjects;
using Trade.UI.Web.Models.ViewModels.Shared;

namespace Trade.UI.Web.Models.ViewModels.Volume
{
    public class VolumeIncreaseViewModel : NavigationViewModel
    {
        public VolumeIncreaseViewModel(VolumeIncreases volumeIncreases)
        {
            Title = CalendarUtility.GetTitle(CalendarEventType.VolumeIncrease);
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
