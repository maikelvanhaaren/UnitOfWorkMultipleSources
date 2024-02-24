namespace Example.UoW;

public interface IUnitOfWork
{
    /// <summary>
    /// Return the enlistment of the given type
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    T Enlistment<T>();
    
    /// <summary>
    /// Commit the enlistments
    /// </summary>
    /// <returns></returns>
    Task CommitAsync();
}