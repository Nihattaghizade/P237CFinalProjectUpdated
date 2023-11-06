using Academy.Core.Enums;

namespace Academy.Service.Services.Interfaces
{
    public interface ITeacherService
    {
        public Task<string> CreateAsync(string name, string surName, string userName, string password, double salary, int age, EducationType educationType);
        public Task<string> UpdateAsync(string id, string name, string surName, string userName, string password, double salary, int age, EducationType educationType);
        public Task<string> RemoveAsync(string id);
        public Task GetAsync(string id);
        public Task GetAllAsync();
    }
}
