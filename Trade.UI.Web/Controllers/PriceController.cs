using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Trade.App.Web.Services;
using Trade.Infra.Contract.Contexts.Application;
using Trade.UI.Web.Controllers.Abstractions;
using Trade.UI.Web.Core.Settings;
using Trade.UI.Web.Models.ViewModels.Price;

namespace Trade.UI.Web.Controllers
{
    public class PriceController : NavigationController
    {
        public PriceController(IApplicationContext appContext, IOptions<AppSettings> settings) : base(appContext, settings)
        {
        }

        public IActionResult Increase(DateTime? date)
        {
            var service = new PriceService(AppContext);
            var priceIncreases = service.GetIncreases(date);

            var model = new PriceIncreaseViewModel(priceIncreases);
            SetNavigationUrl(model);

            return View(model);
        }

        public IActionResult Decrease(DateTime? date)
        {
            var service = new PriceService(AppContext);
            var priceDecreases = service.GetDecreases(date);

            var model = new PriceDecreaseViewModel(priceDecreases);
            SetNavigationUrl(model);

            return View(model);
        }
    }
}
