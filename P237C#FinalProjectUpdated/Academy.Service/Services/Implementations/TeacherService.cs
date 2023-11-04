using Academy.Core.Enums;
using Academy.Core.Models;
using Academy.Core.Repositories;
using Academy.Data.Repositories;
using Academy.Service.Services.Interfaces;

namespace Academy.Service.Services.Implementations
{
    public class TeacherService : ITeacherService
    {
        ITeacherRepository _teacherRepository= new TeacherRepository();

        public async Task<string> CreateAsync(string name, string surName, string userName, string password, double salary, int age, EducationType educationType)
        {
            if (string.IsNullOrWhiteSpace(name))
                return "Name can't be empty";
            if (string.IsNullOrWhiteSpace(surName))
                return "Surname can't be empty";
            if (string.IsNullOrWhiteSpace(userName))
                return "Username can't be empty";
            if (string.IsNullOrWhiteSpace(password))
                return "Password can't be empty";
            if (salary <= 0 || salary > 10000)
                return "Salary can be more than 0 or less than 10000";
            if (age <= 0 || age > 65)
                return "Age can be more than 0 or less than 65";

            Teacher teacher = new Teacher(name,surName, userName, password, salary, age, educationType);
            teacher.CreatedAt = DateTime.UtcNow.AddHours(4);
            await _teacherRepository.CreateAsync(teacher);
            return "Successfully created";
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

        public Task<string> UpdateAsync(string id, string name, string surName, string userName, string password, double salary, int age, EducationType educationType)
        {
            throw new NotImplementedException();
        }
    }
}
