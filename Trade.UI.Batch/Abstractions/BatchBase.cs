using Trade.Infra.Contract.Contexts.Application;

namespace Trade.UI.Batch.Abstractions
{
    public abstract class BatchBase : IBatch
    {
        protected BatchBase(IApplicationContext appContext)
        {
            AppContext = appContext;
        }

        protected IApplicationContext AppContext { get; }

        public abstract BatchResultCode Execute(string argument);
    }
}
