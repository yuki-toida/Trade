using Trade.Infra.Contract.Contexts.Data;
using Trade.Infra.Contract.Serialization.Json;

namespace Trade.Infra.Contract.Contexts.Application
{
    public interface IApplicationContext
    {
        IDataContexts DataContexts { get; }

        IJsonSerializer Serializer { get; }
    }
}
