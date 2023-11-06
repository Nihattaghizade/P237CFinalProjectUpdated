using Academy.Core.Enums;
using Academy.Core.Models;
using Academy.Core.Repositories;
using Academy.Data.Repositories;
using Academy.Service.Services.Interfaces;

namespace Academy.Service.Services.Implementations
{
    public class StudentService : IStudentService, IUserService
    {
        bool IsLogin = false;
        IStudentRepository _studentRepository = new StudentRepository();

        public async Task<bool> Authenticated()
        {
            return IsLogin;
        }

        public async Task<string> CreateAsync(string name, string surName, string userName, string password, int age, EducationType educationType, string group, double average)
        {
            if (string.IsNullOrWhiteSpace(name))
                return "Name can't be empty";
            if (string.IsNullOrWhiteSpace(surName))
                return "Surname can't be empty";
            if (string.IsNullOrWhiteSpace(userName))
                return "Username can't be empty";
            if (string.IsNullOrWhiteSpace(password))
                return "Password can't be empty";
            if (string.IsNullOrWhiteSpace(group))
                return "Group can't be empty";
            if (average <= 0 || average > 100)
                return "Average can be more than 0 or less than 100";

            Student student = new Student(name,surName,userName,password,age,educationType,group,average);
            student.CreatedAt = DateTime.UtcNow.AddHours(4);
            await _studentRepository.CreateAsync(student);
            return "Successfully created";
        }

        public async Task GetAllAsync()
        {
            List<Student> students = await _studentRepository.GetAllAsync();    
            foreach (Student student in students)
            {
                Console.WriteLine($"Id: {student.Id} Name: {student.Name} Surname: {student.SurName} Username: {student.Username} Password: {student.Password} Age: {student.Age} Group: {student.Group} Average: {student.Average} Educationtype: {student.EducationType} CreatedAt: {student.CreatedAt} UpdatedAt: {student.UpdatedAt}");
            }
        }

        public async Task<string> GetAsync(string id)
        {
            Student student = await _studentRepository.GetAsync(x => x.Id == id);
            if (student == null)
                return "Teacher not found";

            Console.WriteLine($"Id: {student.Id} Name: {student.Name} Surname: {student.SurName} Username: {student.Username} Password: {student.Password} Age: {student.Age} Group: {student.Group} Average: {student.Average} Educationtype: {student.EducationType} CreatedAt: {student.CreatedAt} UpdatedAt: {student.UpdatedAt}");
            return "Success";
        }

        public async Task<string> RemoveAsync(string id)
        {
            Student student = await _studentRepository.GetAsync(x => x.Id == id);
            if (student == null)
                return "Teacher not found";

            await _studentRepository.RemoveAsync(student);
            return "Removed successfully";
        }

        public async Task SignIn()
        {
            Console.WriteLine("Add username");
            string Username = Console.ReadLine();
            Console.WriteLine("Add password");
            string Password = Console.ReadLine();
            Student student = await _studentRepository.GetAsync(student => student.Username == Username && student.Password == Password);

            if (student == null)
            {
                //throw new Exception("Username or password is incorrect");
                //return "Username or password is incorrect";
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

        public async Task<string> UpdateAsync(string id, string name, string surName, string userName, string password, int age, EducationType educationType, string group, double average)
        {
            Student student = await _studentRepository.GetAsync(x => x.Id == id);

            if (student == null)
                return "Teacher not found";
            if (string.IsNullOrWhiteSpace(name))
                return "Name can't be empty";
            if (string.IsNullOrWhiteSpace(surName))
                return "Surname can't be empty";
            if (string.IsNullOrWhiteSpace(userName))
                return "Username can't be empty";
            if (string.IsNullOrWhiteSpace(password))
                return "Password can't be empty";
            if (string.IsNullOrWhiteSpace(group))
                return "Group can't be empty";
            if (average <= 0 || average > 100)
                return "Average can be more than 0 or less than 100";

            student.Name = name;
            student.SurName = surName;
            student.Username = userName;
            student.Password = password;
            student.Age = age;
            student.EducationType = educationType;
            student.Group = group;
            student.Average = average;
            student.UpdatedAt = DateTime.UtcNow.AddHours(4);
            return "Updated successfully";
        }
    }
}
