namespace Example;

public class Account
{
    public required string Email { get; set; }
    public required string Password { get; set; }
    public required Guid ActivationCode { get; set; }
}