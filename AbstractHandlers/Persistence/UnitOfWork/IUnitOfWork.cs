namespace AbstractHandlers.Structured.Persistence.UnitOfWork;

public interface IUnitOfWork
{
    Task CompleteAsync();
}