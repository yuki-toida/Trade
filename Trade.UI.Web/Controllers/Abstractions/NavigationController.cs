using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Trade.Infra.Contract.Contexts.Application;
using Trade.UI.Web.Core.Options;
using Trade.UI.Web.Models.ViewModels.Shared;

namespace Trade.UI.Web.Controllers.Abstractions
{
    public abstract class NavigationController : ApplicationController
    {
        protected NavigationController(IApplicationContext appContext, IOptions<CommonOption> optionsAccessor)
            : base(appContext, optionsAccessor)
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

            // 静的ファイルサーバーUrlを設定します
            SetStaticServerUrl(model);
        }
    }
}
