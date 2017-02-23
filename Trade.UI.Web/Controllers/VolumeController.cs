using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Trade.App.Web.Services;
using Trade.Infra.Contract.Contexts.Application;
using Trade.UI.Web.Controllers.Abstractions;

namespace Trade.UI.Web.Controllers
{
    public class VolumeController : ApplicationController
    {
        public VolumeController(IApplicationContext appContext) : base(appContext)
        {
        }

        public IActionResult Index(DateTime? date)
        {
            var service = new VolumeService(AppContext);
            var model = service.GetViewModel(date);
            return View(model);
        }
    }
}
