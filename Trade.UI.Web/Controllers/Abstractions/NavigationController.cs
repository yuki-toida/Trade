using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Trade.Infra.Contract.Contexts.Application;
using Trade.UI.Web.Core.Settings;
using Trade.UI.Web.Models.ViewModels.Shared;

namespace Trade.UI.Web.Controllers.Abstractions
{
    public abstract class NavigationController : ApplicationController
    {
        protected NavigationController(IApplicationContext appContext)
            : base(appContext)
        {
        }

        /// <summary>
        /// ナビゲーションのPreviousUrl/NextUrlを設定します
        /// </summary>
        protected void SetNavigationUrl(NavigationViewModel model)
        {
            var controller = RouteData.Values["controller"].ToString();
            var action = RouteData.Values["action"].ToString();

            model.PreviousUrl = model.PreviousDate.HasValue
                ? Url.Action(action, controller, new { date = model.PreviousDate })
                : "#";

            model.NextUrl = model.NextDate.HasValue
                ? Url.Action(action, controller, new { date = model.NextDate })
                : "#";
        }
    }
}
