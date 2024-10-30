using System.Net;

namespace FIAP.PhaseOne.Api.Controllers.Shared
{
    public class CustomResult
    {
        public bool Success { get; private set; }
        public object Data { get; private set; }
        public IEnumerable<string> Errors { get; private set; }

        public CustomResult(bool success)
        {
            Success = success;
        }

        public CustomResult(bool success, object data) : this(success) =>
            Data = data;

        public CustomResult(bool success, IEnumerable<string> errors) : this(success) =>
            Errors = errors;

        public CustomResult(bool success, object data, IEnumerable<string> errors) : this(success, data) =>
            Errors = errors;
    }
}
