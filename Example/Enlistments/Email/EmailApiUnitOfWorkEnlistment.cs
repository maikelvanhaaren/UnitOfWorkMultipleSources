using Example.UoW;

namespace Example.Enlistments.Email;

public class EmailApiUnitOfWorkEnlistment : IUnitOfWorkEnlistment, IEmailApi
{
    private readonly List<(Func<Task> preCommitAction, Func<Task> rollbackAction)> _operations = [];
    private readonly List<Func<Task>> _rollbackForPreCommittedOperations = [];

    public async Task PreCommitAsync()
    {
        foreach (var operation in _operations)
        {
            await operation.preCommitAction();
            _rollbackForPreCommittedOperations.Add(operation.rollbackAction);
        }
    }

    public async Task RollbackAsync()
    {
        foreach (var rollback in _rollbackForPreCommittedOperations)
        {
            await rollback();
        }
    }
    public Task CommitAsync() => Task.CompletedTask;


    public Task SendEmailAsync(string to, string subject, string body)
    {
        var commitAction = new Func<Task>(() =>
        {
            Console.WriteLine($"Sending email: {to} - {subject} - {body}");
            return Task.CompletedTask;
        });
        
        var rollbackAction = new Func<Task>(() =>
        {
            Console.WriteLine($"Rolling back email: {to} - {subject} - {body}");
            return Task.CompletedTask;
        });
        
        _operations.Add((commitAction, rollbackAction));
        
        return Task.CompletedTask;
    }

    public Task ThrowExceptionSendEmailAsync(string to, string subject, string body)
    {
        var commitAction = new Func<Task>(() => Task.FromException(new InvalidOperationException("Email sending failed")));
        
        var rollbackAction = new Func<Task>(() =>
        {
            Console.WriteLine($"Rolling back email: {to} - {subject} - {body}");
            return Task.CompletedTask;
        });
        
        _operations.Add((commitAction, rollbackAction));
        
        return Task.CompletedTask;
    }
}