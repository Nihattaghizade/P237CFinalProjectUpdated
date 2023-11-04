using Academy.Core.Enums;
using Academy.Core.Models.BaseModels;

namespace Academy.Core.Models
{
    public class Teacher : BaseModel
    {
        static int _id;
        public string Name { get; set; }
        public string SurName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public double Salary { get; set; }
        public int Age { get; set; }
        public EducationType EducationType { get; set; }

        public Teacher(string name,string surName,string userName,string password,double salary,int age,EducationType educationType)
        {
            _id++;

            Name = name;
            SurName = surName;
            Username= userName;
            Password = password;
            Salary = salary;
            Age = age;
            EducationType = educationType;
            Id = $"{EducationType.ToString()[0]}-{_id}";
        }
    }
}
