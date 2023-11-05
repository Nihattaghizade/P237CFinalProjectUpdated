using Academy.Core.Repositories;
using Academy.Data.Repositories;
using Academy.Service.Services.Interfaces;

namespace Academy.Service.Services.Implementations
{
    public class DeveloperService : IDeveloperService
    {
        IDeveloperRepository _developerRepository = new DeveloperRepository();
        public async Task<string> CreateAsync(string name, string surName, string userName, string password, double salary, int age)
        {
            throw new NotImplementedException();
        }

        public async Task GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<string> GetAsync(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<string> RemoveAsync(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<string> UpdateAsync(string id, string name, string surName, string userName, string password, double salary, int age)
        {
            throw new NotImplementedException();
        }
    }
}
