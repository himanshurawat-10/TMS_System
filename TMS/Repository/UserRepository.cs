using Microsoft.EntityFrameworkCore;
using TMS.Context;
using TMS.Interface;
using TMS.Models;

namespace TMS.Repository
{
    public class UserRepository : IUser
    {
        MyDBContext _db;

        public UserRepository(MyDBContext db)
        {
            _db = db;
        }

        public User Create(User user)
        {
            _db.Add(user);
            _db.SaveChanges();
            return user;
        }

        public int Delete(int id)
        {
            User obj = GetUserById(id);
            if (obj != null)
            {
                obj.IsActive = false;
                _db.SaveChanges();
                return 0;
            }
            else
            {
                return 1;
            }
        }

        public int Edit(int id, User user)
        {
            User obj = GetUserById(id);
            if (obj != null)
            {
                foreach (User temp in _db.Users)
                {
                    if (temp.UId == id)
                    {
                        temp.Name = user.Name;
                        temp.RoleName = user.RoleName;
                        temp.ManagerId = user.ManagerId;
                    }
                }
                _db.SaveChanges();
                return 0;
            }

            else return 1;
        }

        public List<User> GetUser()
        {
            return _db.Users.ToList();
        }

        public User GetUserById(int id)
        {
            return _db.Users.FirstOrDefault(x => x.UId == id);
        }

        public List<UserManagerViewModel> GetUserV()
        {

            var list = (
         from user in _db.Users
         join emp in _db.Users
         on user.UId equals emp.ManagerId

         select new UserManagerViewModel
         {
             UserName = emp.Name,
             Email = user.Email,
             ManagerName = user.Name,
             Role = emp.RoleName

         }).ToList();
            return list;

        }
        

        public User ValidateUser(string uname, string password)
        {
            return _db.Users.FirstOrDefault( x => x.Email.Equals(uname) && x.Password.Equals(password) );

        }

       
    }
}
