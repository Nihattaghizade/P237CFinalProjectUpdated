using Academy.Core.Models.BaseModels;

namespace Academy.Core.Models
{
    public class Developer : BaseModel
    {
        static int _id;
        public double Salary { get; set; }
        public int Age { get; set; }

        public Developer(string name,string surName,string userName,string password,double salary,int age)
        {
            _id++;

            Name = name;
            SurName = surName;
            Username = userName;
            Password = password;
            Salary = salary;
            Age = age;
            Id = $"{_id}-D";
        }
    }
}
