using System.Linq;
using Trade.Domain.Entities.Price;
using Trade.Domain.ValueObjects;
using Trade.Infra.Core.Extensions;
using Trade.UI.Web.Models.ViewModels.Shared;

namespace Trade.UI.Web.Models.ViewModels.Price
{
    public class PriceIncreaseViewModel : NavigationViewModel
    {
        public PriceIncreaseViewModel(PriceIncreases priceIncreases)
        {
            Title = CalendarEventType.PriceIncrease.GetValue<string>();
            EventType = CalendarEventType.PriceIncrease;
            TargetDate = priceIncreases.TargetDate;
            PreviousDate = priceIncreases.PreviousDate;
            NextDate = priceIncreases.NextDate;
            Items = priceIncreases.Select(x => new PriceIncreaseItemViewModel(x)).ToArray();
        }

        public PriceIncreaseItemViewModel[] Items { get; set; }
    }
}
