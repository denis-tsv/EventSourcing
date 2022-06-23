namespace Shop.Web.UseCases.Exceptions;

public class EntityNotFoundException : Exception
{
    public EntityNotFoundException(int id, string entityType) : base($"Not found {entityType} with id = '{id}'")
    {
    }
}