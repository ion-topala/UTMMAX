namespace UTMMAX.Service;

public interface IServiceModelValidator
{
    Task ValidateAndThrowAsync<T>(T model, IDictionary<string, object> ctxData = null);
}