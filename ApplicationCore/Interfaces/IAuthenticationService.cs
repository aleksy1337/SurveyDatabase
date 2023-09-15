using ApplicationCore.Models;

namespace ApplicationCore.Interfaces
{
    public interface IAuthenticationService
    {
        string Login(string username, string password);
        string Register(string username, string email, string password, string firstname, string lastname, string phoneNumber);
    }
}
