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

        public async Task GetAllAsync()
        {
            List<Teacher> teachers = await _teacherRepository.GetAllAsync();
            foreach (Teacher teacher in teachers)
            {
                Console.WriteLine($"Id: {teacher.Id} Name: {teacher.Name} Surname: {teacher.SurName} Username: {teacher.Username} Password: {teacher.Password} Salary:{teacher.Salary} Age: {teacher.Age} Educationtype: {teacher.EducationType} CreatedAt: {teacher.CreatedAt} UpdatedAt: {teacher.UpdatedAt}");
            }
        }

        public async Task<string> GetAsync(string id)
        {
            Teacher teacher = await _teacherRepository.GetAsync(x => x.Id == id);
            if (teacher == null)
                return "Teacher not found";

            Console.WriteLine($"Id: {teacher.Id} Name: {teacher.Name} Surname: {teacher.SurName} Username: {teacher.Username} Password: {teacher.Password} Salary:{teacher.Salary} Age: {teacher.Age} Educationtype: {teacher.EducationType} CreatedAt: {teacher.CreatedAt} UpdatedAt: {teacher.UpdatedAt}");
            return "Success";
        }

        public async Task<string> RemoveAsync(string id)
        {
            Teacher teacher = await _teacherRepository.GetAsync(x => x.Id == id);
            if (teacher == null)
                return "Teacher not found";

            await _teacherRepository.RemoveAsync(teacher);
            return "Removed successfully";
        }

        public async Task<string> UpdateAsync(string id, string name, string surName, string userName, string password, double salary, int age, EducationType educationType)
        {
            Teacher teacher = await _teacherRepository.GetAsync(x => x.Id == id);

            if (teacher == null)
                return "Teacher not found";
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

            teacher.Name = name;
            teacher.SurName = surName;
            teacher.Username = userName;
            teacher.Password = password;
            teacher.Salary = salary;
            teacher.Age = age;
            teacher.EducationType = educationType;
            teacher.UpdatedAt = DateTime.UtcNow.AddHours(4);
            return "Updated successfully";
        }
    }
}
