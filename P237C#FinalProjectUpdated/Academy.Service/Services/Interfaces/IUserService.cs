namespace Academy.Service.Services.Interfaces
{
    public interface IUserService
    {
        public Task SignIn();
        public Task SignOut();
        public Task<bool> Authenticated();
    }
}
