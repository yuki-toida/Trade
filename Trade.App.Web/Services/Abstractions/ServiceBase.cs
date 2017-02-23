using Trade.Infra.Contract.Contexts.Application;

namespace Trade.App.Web.Services.Abstractions
{
    public abstract class ServiceBase
    {
        protected ServiceBase(IApplicationContext appContext)
        {
            AppContext = appContext;
        }

        protected IApplicationContext AppContext { get; }
    }
}
