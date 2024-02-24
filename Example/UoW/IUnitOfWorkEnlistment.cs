namespace Example.UoW;

public interface IUnitOfWorkEnlistment
{
    /// <summary>
    /// Commit the changes in a way that it can be rolled back when needed
    /// </summary>
    Task PreCommitAsync();
    
    /// <summary>
    /// Commit the changes. This method is called when all the pre-commit operations are successful.
    /// </summary>
    Task CommitAsync();
    
    /// <summary>
    /// Rollback the changes. This method is called when any of the pre-commit operations fail.
    /// </summary>
    Task RollbackAsync();
}