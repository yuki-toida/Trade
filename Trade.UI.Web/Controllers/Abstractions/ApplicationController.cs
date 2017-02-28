using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Trade.Infra.Contract.Contexts.Application;
using Trade.UI.Web.Core.Settings;
using Trade.UI.Web.Models.ViewModels.Shared;

namespace Trade.UI.Web.Controllers.Abstractions
{
    public abstract class ApplicationController : Controller
    {
        protected ApplicationController(IApplicationContext appContext, IOptions<AppSettings> settings)
        {
            AppContext = appContext;
            Settings = settings.Value;
        }

        protected IApplicationContext AppContext { get; }
        protected AppSettings Settings { get; }

        /// <summary>
        /// 静的ファイルサーバーUrlを設定します
        /// </summary>
        protected void SetStaticServerUrl(CommonViewModel model)
        {
            model.StaticServerUrl = Settings.StaticServerUrl;
        }
    }
}
