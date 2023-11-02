namespace N64_HT1_Entity.Domain.Entites;

public class User
{
    public Guid Id { get; set; }
    public string FirstName { get; set; } = default!;
    public string LastName { get; set; }= default!;
    public int  Age { get; set; }
    public string EmailAddress { get; set; } = default!;
    public string PasswordHash { get; set; } = default!;  
    public bool IsEmailAddressVerified { get; set; }
}
