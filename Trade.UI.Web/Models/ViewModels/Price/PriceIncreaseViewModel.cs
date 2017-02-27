using System.Linq;
using Trade.Domain.Entities.Price;
using Trade.Domain.Services.Utilities;
using Trade.Domain.ValueObjects;
using Trade.UI.Web.Models.ViewModels.Shared;

namespace Trade.UI.Web.Models.ViewModels.Price
{
    public class PriceIncreaseViewModel : NavigationViewModel
    {
        public PriceIncreaseViewModel(PriceIncreases priceIncreases)
        {
            Title = CalendarUtility.GetTitle(CalendarEventType.PriceIncrease);
            EventType = CalendarEventType.PriceIncrease;
            TargetDate = priceIncreases.TargetDate;
            PreviousDate = priceIncreases.PreviousDate;
            NextDate = priceIncreases.NextDate;
            Items = priceIncreases.Select(x => new PriceIncreaseItemViewModel(x)).ToArray();
        }

        public PriceIncreaseItemViewModel[] Items { get; set; }
    }
}
