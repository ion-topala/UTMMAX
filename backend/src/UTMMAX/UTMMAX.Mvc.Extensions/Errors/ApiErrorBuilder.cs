namespace UTMMAX.Mvc.Extensions.Errors
{
    public class ApiErrorBuilder
    {
        private string _area;
        private string _action;
        private string _code;
        private string _message;

        private ApiErrorBuilder(string area, string action)
        {
            _area = area;
            _action = action;
        }

        public static ApiErrorBuilder New(string area, string action)
        {
            var builder = new ApiErrorBuilder(area, action);

            return builder;
        }

        public ApiErrorBuilder SetCode(string code)
        {
            _code = code;

            return this;
        }

        public ApiErrorBuilder SetMessage(string message)
        {
            _message = message;

            return this;
        }

        public ApiErrorModel Build()
        {
            return new ApiErrorModel
            {
                Code = GenerateErrorCode(_code),
                Message = _message,
            };
        }

        private string GenerateErrorCode(string code)
        {
            return $"{_area}.{_action}.{code}";
        }
    }
}