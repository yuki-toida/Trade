using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Trade.App.Web.Services;
using Trade.Infra.Contract.Contexts.Application;
using Trade.UI.Web.Controllers.Abstractions;
using Trade.UI.Web.Core.Settings;
using Trade.UI.Web.Models.ViewModels.Volume;

namespace Trade.UI.Web.Controllers
{
    public class VolumeController : NavigationController
    {
        public VolumeController(IApplicationContext appContext, IOptions<AppSettings> settings) : base(appContext, settings)
        {
        }

        public IActionResult Increase(DateTime? date)
        {
            var service = new VolumeService(AppContext);
            var volumeIncreases = service.GetIncreases(date);

            var model = new VolumeIncreaseViewModel(volumeIncreases);
            SetNavigationUrl(model);

            return View(model);
        }
    }
}
