using Newtonsoft.Json.Serialization;

namespace FIAP.PhaseOne.Api.Extensions
{
    public class LowercaseContractResolver : DefaultContractResolver
    {
        protected override string ResolvePropertyName(string propertyName)
        {
            return char.ToLower(propertyName[0]) + propertyName.Substring(1);
        }
    }
}
