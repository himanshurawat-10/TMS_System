using TMS.Models;

namespace TMS.Interface
{
    public interface IUser
    {

        List<User> GetUser();
        List<UserManagerViewModel> GetUserV();
        User Create(User user);
        User GetUserById(int id);
        int Edit(int id, User user);
        int Delete(int id);

        User ValidateUser(string uname, string password);
    }
}
