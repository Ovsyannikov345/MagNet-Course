namespace BusinessLogic
{
    public interface IAuthService
    {
        public bool CheckLogin(string login);

        public User Authorize(string login, string password);

        public User Register(string login, string password);
    }
}
