using Academy.Service.Services.Interfaces;

namespace Academy.Service.Services.Implementations
{
    public class CEOService : IUserService
    {
        bool IsLogin = false;
        public async Task<bool> Authenticated()
        {
            return IsLogin;
        }

        public async Task SignIn()
        {
            Console.WriteLine("Add username");
            string Username = Console.ReadLine();
            Console.WriteLine("Add password");
            string Password = Console.ReadLine();

            if (Username == "Nihattt" && Password == "Nihat123")
            {
                Console.WriteLine("Username or password is incorrect");
            }
            else
            {
                IsLogin = true;
            }
            Console.WriteLine("Signed in successfully");
        }

        public async Task SignOut()
        {
            if (IsLogin == true)
            {
                IsLogin = false;
            }
            Console.WriteLine("Signed out successfully");
        }
    }
}
