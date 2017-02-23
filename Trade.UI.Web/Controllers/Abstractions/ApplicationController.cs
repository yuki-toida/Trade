using Microsoft.AspNetCore.Mvc;
using Trade.Infra.Contract.Contexts.Application;

namespace Trade.UI.Web.Controllers.Abstractions
{
    public abstract class ApplicationController : Controller
    {
        protected ApplicationController(IApplicationContext appContext)
        {
            AppContext = appContext;
        }

        protected IApplicationContext AppContext { get; }
    }
}
