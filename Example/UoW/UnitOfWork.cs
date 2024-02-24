namespace Example.UoW;

public class UnitOfWork(params IUnitOfWorkEnlistment[] enlistments) : IUnitOfWork
{
    public T Enlistment<T>() => enlistments.OfType<T>().SingleOrDefault()
                                ?? throw new InvalidOperationException(
                                    $"Enlistment of type {typeof(T).Name} not found");

    public async Task CommitAsync()
    {
        var successfullyPreCommitted = new List<IUnitOfWorkEnlistment>();

        try
        {
            foreach (var enlistment in enlistments)
            {
                await enlistment.PreCommitAsync();
                successfullyPreCommitted.Add(enlistment);
            }
        }
        catch (Exception)
        {
            foreach (var needsRollbackEnlistment in successfullyPreCommitted)
            {
                await needsRollbackEnlistment.RollbackAsync();
            }

            throw;
        }

        foreach (var enlistment in enlistments)
        {
            await enlistment.CommitAsync();
        }
    }
}