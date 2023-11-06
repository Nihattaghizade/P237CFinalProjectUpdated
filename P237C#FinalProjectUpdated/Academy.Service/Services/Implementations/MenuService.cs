using Academy.Service.Services.Interfaces;

namespace Academy.Service.Services.Implementations
{
    public class MenuService
    {
        CEOService ceoService = new CEOService();
        StudentService studentService = new StudentService();
        TeacherService teacherService = new TeacherService();
        DeveloperService developerService = new DeveloperService();













        //async Task Menu()
        //{
        //    if (!userService.Authenticated())
        //    {
        //        Console.WriteLine("1. SignIn");
        //    }
        //    else
        //    {
        //        Console.WriteLine("2. SignOut");
        //        Console.WriteLine("3. Get all users");
        //    }
        //    Console.WriteLine("0. Close");
        //}
    }
}
