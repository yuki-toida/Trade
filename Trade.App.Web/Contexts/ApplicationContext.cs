using Trade.Infra.Contract.Contexts.Application;
using Trade.Infra.Contract.Contexts.Data;
using Trade.Infra.Contract.Serialization.Json;

namespace Trade.App.Web.Contexts
{
    public class ApplicationContext : IApplicationContext
    {
        public ApplicationContext(IDataContexts dataContexts, IJsonSerializer serializer)
        {
            DataContexts = dataContexts;
            Serializer = serializer;
        }

        public IDataContexts DataContexts { get; }

        public IJsonSerializer Serializer { get; }
    }
}
