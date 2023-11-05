using Academy.Core.Enums;
using Academy.Core.Models.BaseModels;

namespace Academy.Core.Models
{
    public class Student : BaseModel
    {
        static int _id;
        public int Age { get; set; }
        public EducationType EducationType { get; set; }
        public string Group { get; set; }
        public double Average { get; set; }

        public Student(string name,string surName, string userName, string password, int age, EducationType educationType, string group, double average)
        {
            _id++;

            Name = name;
            SurName = surName;
            Username = userName;
            Password = password;
            Age = age;
            EducationType = educationType;
            Id = $"{EducationType.ToString()[0]}-{_id}-S";
            Group = group;
            Average = average;

        }
    }
}
