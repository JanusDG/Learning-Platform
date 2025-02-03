public interface ILearningPlatformService 
{
    public void ListUsers();
    public void ListCourses();
    public void RegisterUser(string name);
    public void LoginUser();
    public void UpdateUser(int id, string updatedName);
    public void DeleteUser(int id);
    public void AddCourse(string courseName);
    public void UpdateCourse(int id, string updatedName);
    public void DeleteCourse(int id);
    public void AssignCourseUser(int userId, int courseId);
    public void ListAssignedCoursesUser(int userId);
    public void ListAssignedUsersCourse(int courseId);


}