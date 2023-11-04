using Academy.Core.Enums;

namespace Academy.Service.Services.Interfaces
{
    public interface IStudentService
    {
        public Task<string> CreateAsync(string name, string surName, string userName, string password, int age, EducationType educationType, string group, double average);
        public Task<string> UpdateAsync(string id, string name, string surName, string userName, string password, int age, EducationType educationType, string group, double average);
        public Task<string> RemoveAsync(string id);
        public Task<string> GetAsync(string id);
        public Task GetAllAsync();
    }
}
