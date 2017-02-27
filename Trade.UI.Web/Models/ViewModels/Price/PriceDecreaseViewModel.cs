using System.Linq;
using Trade.Domain.Entities.Price;
using Trade.Domain.Services.Utilities;
using Trade.Domain.ValueObjects;
using Trade.UI.Web.Models.ViewModels.Shared;

namespace Trade.UI.Web.Models.ViewModels.Price
{
    public class PriceDecreaseViewModel : NavigationViewModel
    {
        public PriceDecreaseViewModel(PriceDecreases priceDecreases)
        {
            Title = CalendarUtility.GetTitle(CalendarEventType.PriceDecrease);
            EventType = CalendarEventType.PriceDecrease;
            TargetDate = priceDecreases.TargetDate;
            PreviousDate = priceDecreases.PreviousDate;
            NextDate = priceDecreases.NextDate;
            Items = priceDecreases.Select(x => new PriceDecreaseItemViewModel(x)).ToArray();
        }

        public PriceDecreaseItemViewModel[] Items { get; set; }
    }
}
