using LearningPlatform.Models;
using LearningPlatform.Data;
using LearningPlatform.Services;

class Program
{
    static void Main()
    {
        var context = new LearningPlatformDbContext();
        context.Database.EnsureCreated();
        var learningPlatformService = new LearningPlatformService(context);

        
        var loop = true;
        while (loop) 
        {
            Console.WriteLine(@"Enter command from list:
            lu - ListUsers
            lc - ListCourses
            cu - CreateUser
            uu - UpdateUser
            du - DeleteUser
            ac - AddCourse
            uc - UpdateCourse
            dc - DeleteCourse
            acu - AssignCourseUser
            lauc - ListAssignedUsersCourse
            lacu - ListAssignedCoursesUser
            ");
            var input = Console.ReadLine();
            switch (input){

                case "lu":
                    ListUsersCLI(learningPlatformService);
                    break;
                case "lc":
                    ListCoursesCLI(learningPlatformService);
                    break;
                case "cu":
                    CreateUserCLI(learningPlatformService);
                    break;
                case "uu":
                    UpdateUserCLI(learningPlatformService);
                    break;
                case "du":
                    DeleteUserCLI(learningPlatformService);
                    break;
                case "ac":
                    AddCourseCLI(learningPlatformService);
                    break;
                case "uc":
                    UpdateCourseCLI(learningPlatformService);
                    break;
                case "dc":
                    DeleteCourseCLI(learningPlatformService);
                    break;
                case "acu":
                    UserAssignCourseCLI(learningPlatformService);
                    break;
                case "lauc":
                    ListAssignedUsersCourseCLI(learningPlatformService);
                    break;
                case "lacu":
                    ListAssignedCoursesUserCLI(learningPlatformService);
                    break;
                    
                case "":
                    loop = false;
                    break;

            }
        }
    }


    static void ListAssignedUsersCourseCLI(LearningPlatformService learningPlatformService)
    {
        Console.WriteLine("Id of course with assigned users: ");
        int courseId = int.Parse(Console.ReadLine());
        learningPlatformService.ListAssignedUsersCourse(courseId);
    }
    static void ListAssignedCoursesUserCLI(LearningPlatformService learningPlatformService)
    {
        Console.WriteLine("Id of user to list assigned courses: ");
        int userId = int.Parse(Console.ReadLine());
        learningPlatformService.ListAssignedCoursesUser(userId);
    }
    static void UserAssignCourseCLI(LearningPlatformService learningPlatformService)
    {
        Console.WriteLine("Id of user to assign to: ");
        int userId = int.Parse(Console.ReadLine());
        Console.WriteLine("Id of course to assign: ");
        int courseId = int.Parse(Console.ReadLine());

        learningPlatformService.AssignCourseUser(userId, courseId);
    }

    static void ListUsersCLI(LearningPlatformService learningPlatformService)
    {
        learningPlatformService.ListUsers();
    }

    static void ListCoursesCLI(LearningPlatformService learningPlatformService)
    {
        learningPlatformService.ListCourses();
    }
    static void CreateUserCLI(LearningPlatformService learningPlatformService)
    {
        Console.WriteLine("Name of user to add: ");
        string userName = Console.ReadLine();
        learningPlatformService.RegisterUser(userName);
    }

    static void UpdateUserCLI(LearningPlatformService learningPlatformService)
    {
        Console.WriteLine("Id of user to update: ");
        int userId = int.Parse(Console.ReadLine());
        Console.WriteLine("New name for user: ");
        string updatedUserName = Console.ReadLine();
        learningPlatformService.UpdateUser(userId, updatedUserName);
    }

    static void DeleteUserCLI(LearningPlatformService learningPlatformService)
    {
        Console.WriteLine("Id of user to delete: ");
        int userId = int.Parse(Console.ReadLine());
        learningPlatformService.DeleteUser(userId);
    }
    static void AddCourseCLI(LearningPlatformService learningPlatformService)
    {
        Console.WriteLine("Name of course to add: ");
        string courseName = Console.ReadLine();
        learningPlatformService.AddCourse(courseName);
    }
    static void UpdateCourseCLI(LearningPlatformService learningPlatformService)
    {
        Console.WriteLine("Id of course to update: ");
        int courseId = int.Parse(Console.ReadLine());
        Console.WriteLine("New name for course: ");
        string updatedCourseName = Console.ReadLine();
        learningPlatformService.UpdateCourse(courseId, updatedCourseName);
    }
    static void DeleteCourseCLI(LearningPlatformService learningPlatformService)
    {
        Console.WriteLine("Id of course to delete: ");
        int courseId = int.Parse(Console.ReadLine());
        learningPlatformService.DeleteCourse(courseId);
    }
    
}
