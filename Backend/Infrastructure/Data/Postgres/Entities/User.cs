using Infrastructure.Data.Postgres.Entities.Base;

namespace Infrastructure.Data.Postgres.Entities;

public class User : Entity<int>
{
    public string Email { get; set; } = default!;
    public string UserName { get; set; } = default!;
    public string FirstName { get; set; } = default!;
    public string LastName { get; set; } = default!;
    public int Age { get; set; } = default!;
    public byte[] PasswordSalt { get; set; } = default!;
    public byte[] PasswordHash { get; set; } = default!;
    public UserType UserType { get; set; }
    public IList<Prescriptions> Prescriptions { get; set; }
    public IList<Appointment > Appointments { get; set; }
    public IList<UserComment> UserComments { get; set; }
}

public enum UserType
{
    Admin,
    Doctor,
    Secretary,
    Patient
}
