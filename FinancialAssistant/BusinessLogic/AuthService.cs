using Common;
using System.Collections.Generic;

namespace BusinessLogic
{
    public class AuthService : IAuthService
    {
        private readonly IDataManager dataProvider;

        private List<User> userList;

        public AuthService(IDataManager dataProvider)
        {
            this.dataProvider = dataProvider;
            userList = this.dataProvider.LoadUsers<List<User>>();
        }

        public bool CheckLogin(string login)
        {
            if (userList != null && userList.Find(user => user.Login == login) != default(User))
            {
                return true;
            }

            return false;
        }

        public User Authorize(string login, string password)
        {
            return userList.Find(user => user.Login == login && user.Password == password);
        }

        public User Register(string login, string password)
        {
            if (userList == null)
            {
                userList = new List<User>(1);
            }

            User newUser = new User(login, password);

            userList.Add(newUser);
            dataProvider.SaveUsers(userList);

            return newUser;
        }
    }
}
