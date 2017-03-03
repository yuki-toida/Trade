using System.Linq;
using Trade.Domain.Entities.Price;
using Trade.Domain.ValueObjects;
using Trade.Infra.Core.Extensions;
using Trade.UI.Web.Models.ViewModels.Shared;

namespace Trade.UI.Web.Models.ViewModels.Price
{
    public class PriceDecreaseViewModel : NavigationViewModel
    {
        public PriceDecreaseViewModel(PriceDecreases priceDecreases)
        {
            Title = CalendarEventType.PriceDecrease.GetValue<string>();
            EventType = CalendarEventType.PriceDecrease;
            TargetDate = priceDecreases.TargetDate;
            PreviousDate = priceDecreases.PreviousDate;
            NextDate = priceDecreases.NextDate;
            Items = priceDecreases.Select(x => new PriceDecreaseItemViewModel(x)).ToArray();
        }

        public PriceDecreaseItemViewModel[] Items { get; set; }
    }
}
