namespace APE.Core.Interfaces
{
    public interface IUser
    {
        int Id { get; set; }
        string Username { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
    }
}
