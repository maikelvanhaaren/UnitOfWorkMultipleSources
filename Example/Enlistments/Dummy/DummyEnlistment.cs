using Example.UoW;

namespace Example.Enlistments.Dummy;

public class DummyEnlistment : IUnitOfWorkEnlistment
{
    private readonly string _name;
    
    private readonly bool _preCommitThrowException;
    
    private bool _isPreCommittedCalled;
    private bool _isCommittedCalled;
    private bool _isRolledBackCalled;

    public DummyEnlistment(string name, bool preCommitThrowException)
    {
        _name = name;
        _preCommitThrowException = preCommitThrowException;
    }
    
    public static DummyEnlistment CreatePreCommitFails(string name) => new(name, true);
    public static DummyEnlistment Create(string name) => new(name, false);

    public Task PreCommitAsync()
    {
        _isPreCommittedCalled = true;

        if (_preCommitThrowException)
        {
            throw new Exception("PreCommit failed");
        }
        
        return Task.CompletedTask;
    }

    public Task CommitAsync()
    {
        _isCommittedCalled = true;

        return Task.CompletedTask;
    }

    public Task RollbackAsync()
    {
        _isRolledBackCalled = true;

        return Task.CompletedTask;
    }
    
    public string GetStatus()
    {
        return $"{_name} - PreCommitted called: {_isPreCommittedCalled}, Committed called: {_isCommittedCalled}, Rollbacked called: {_isRolledBackCalled}";
    }
}