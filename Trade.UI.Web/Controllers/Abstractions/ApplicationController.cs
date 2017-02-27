using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Trade.Infra.Contract.Contexts.Application;
using Trade.UI.Web.Core.Options;
using Trade.UI.Web.Models.ViewModels.Shared;

namespace Trade.UI.Web.Controllers.Abstractions
{
    public abstract class ApplicationController : Controller
    {
        protected ApplicationController(IApplicationContext appContext, IOptions<CommonOption> optionsAccessor)
        {
            AppContext = appContext;
            Option = optionsAccessor.Value;
        }

        protected IApplicationContext AppContext { get; }
        protected CommonOption Option { get; }

        /// <summary>
        /// 静的ファイルサーバーUrlを設定します
        /// </summary>
        protected void SetStaticServerUrl(CommonViewModel model)
        {
            model.StaticServerUrl = Option.StaticServerUrl;
        }
    }
}
