using Academy.Core.Enums;
using Academy.Core.Models;
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
            if(string.IsNullOrWhiteSpace(name))
                return "Name can't be empty";
            if (string.IsNullOrWhiteSpace(surName))
                return "Surname can't be empty";
            if (string.IsNullOrWhiteSpace(userName))
                return "Username can't be empty";
            if (string.IsNullOrWhiteSpace(password))
                return "Password can't be empty";
            if (salary <= 0 || salary > 10000)
                return "Salary can be more than 0 or less than 10000";
            if (age <= 0 || age > 40)
                return "Age can be more than 0 or less than 40";

            Developer developer = new Developer(name,surName,userName,password,salary,age);
            developer.CreatedAt = DateTime.UtcNow.AddHours(4);
            await _developerRepository.CreateAsync(developer);
            return "Successfully created";
        }

        public async Task GetAllAsync()
        {
            List<Developer> developers = await _developerRepository.GetAllAsync();
            foreach(Developer developer in developers)
            {
                Console.WriteLine($"Id: {developer.Id} Name: {developer.Name} Surname: {developer.SurName} Username: {developer.Username} Password: {developer.Password} Salary:{developer.Salary} Age: {developer.Age} CreatedAt: {developer.CreatedAt} UpdatedAt: {developer.UpdatedAt}");
            }
        }

        public async Task<string> GetAsync(string id)
        {
            Developer developer = await _developerRepository.GetAsync(x => x.Id == id);
            if (developer == null)
                return "Developer not found";

            Console.WriteLine($"Id: {developer.Id} Name: {developer.Name} Surname: {developer.SurName} Username: {developer.Username} Password: {developer.Password} Salary:{developer.Salary} Age: {developer.Age} CreatedAt: {developer.CreatedAt} UpdatedAt: {developer.UpdatedAt}");
            return "Success";
        }

        public async Task<string> RemoveAsync(string id)
        {
            Developer developer = await _developerRepository.GetAsync(x => x.Id == id);
            if (developer == null)
                return "Developer not found";

            await _developerRepository.RemoveAsync(developer);
            return "Removed successfully";
        }

        public async Task<string> UpdateAsync(string id, string name, string surName, string userName, string password, double salary, int age)
        {
            Developer developer = await _developerRepository.GetAsync(x => x.Id == id);

            if (developer == null)
                return "Developer not found";
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
            if (age <= 0 || age > 40)
                return "Age can be more than 0 or less than 65";

            developer.Name = name;
            developer.SurName = surName;
            developer.Username = userName;
            developer.Password = password;
            developer.Salary = salary;
            developer.Age = age;
            developer.UpdatedAt = DateTime.UtcNow.AddHours(4);
            return "Updated successfully";
        }
    }
}
