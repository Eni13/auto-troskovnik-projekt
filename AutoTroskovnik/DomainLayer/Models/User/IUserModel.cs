namespace DomainLayer.Models.User
{
    public interface IUserModel
    {
        string CarModel { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
        int UserId { get; set; }
    }
}