using Academy.Core.Enums;
using Academy.Core.Repositories;
using Academy.Data.Repositories;
using Academy.Service.Services.Interfaces;

namespace Academy.Service.Services.Implementations
{
    public class StudentService : IStudentService
    {
        IStudentRepository _studentRepository = new StudentRepository();
        public Task<string> CreateAsync(string name, string surName, string userName, string password, int age, EducationType educationType, string group, double average)
        {
            throw new NotImplementedException();
        }

        public Task GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<string> GetAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<string> RemoveAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<string> UpdateAsync(string id, string name, string surName, string userName, string password, int age, EducationType educationType, string group, double average)
        {
            throw new NotImplementedException();
        }
    }
}
