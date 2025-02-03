using System.Linq;
using Microsoft.EntityFrameworkCore;

using LearningPlatform.Models;
using LearningPlatform.Data;

namespace LearningPlatform.Services
{
    public class LearningPlatformService : ILearningPlatformService
    {

        public readonly LearningPlatformDbContext _context;
        
        public LearningPlatformService(LearningPlatformDbContext learningPlatformDbContext)
        {
            _context = learningPlatformDbContext;
        }
        // temporary 
        public void ListUsers()
        {
            
            _context.Users
                .Select(u => new{u.Id,u.Value})
                .ToList()
                .ForEach(Console.WriteLine);
            
        }
        public void ListCourses()
        {
            
            _context.Courses
                .Select(c => new{c.Id,c.Value})
                .ToList()
                .ForEach(Console.WriteLine);
            
        }
        public void RegisterUser(string name)
        {
            
            _context.Users.Add(new User { Value = name });
            _context.SaveChanges();
            
        }
        public void LoginUser()
        {
            throw new NotImplementedException();

        }
        public void UpdateUser(int id, string updatedName)
        {
            var user = _context.Users.Find(id); 
            if (user != null)
            {
                user.Value = updatedName;
                _context.SaveChanges();
            }
        }
        public void DeleteUser(int id)
        {
            var user = _context.Users.Find(id);  
            if (user != null)
            {
                _context.Users.Remove(user);
                _context.SaveChanges();     
            }

        }
        public void AddCourse(string courseName)
        {
            _context.Courses.Add(new Course { Value = courseName });
            _context.SaveChanges();

        }
        public void UpdateCourse(int id, string updatedName)
        {
            var course = _context.Courses.Find(id); 
            if (course != null)
            {
                course.Value = updatedName;
                _context.SaveChanges();
            }

        }
        public void DeleteCourse(int id)
        {
            var course = _context.Courses.Find(id);  
            if (course != null)
            {
                _context.Courses.Remove(course);
                _context.SaveChanges();     
            }

        }

        public void AssignCourseUser(int userId, int courseId)
        {
            var user = _context.Users.FirstOrDefault(u => u.Id == userId);
            var course = _context.Courses.FirstOrDefault(c => c.Id == courseId);
            if (user == null || course == null)
            {
                // TODO don't forget to handle this somehow when the rest of logic will be implemented
                return;
            }
            var userCourse = new UserCourse
            {
                UserId = user.Id,
                CourseId = course.Id
            };

            // Add the entry to the UserCourses table
            _context.UserCourses.Add(userCourse);
            _context.SaveChanges();


        }

        public void ListAssignedCoursesUser(int userId)
        {
            _context.UserCourses
                .Where(uc => uc.UserId == userId)
                .Join(_context.Courses,
                    uc => uc.CourseId,
                    c => c.Id,
                    (uc, c) => c.Value )
                .ToList()
                .ForEach(Console.WriteLine);
            
            // TODO: Discuss this with Mykola
            // or this: 

            // _context.UserCourses
            //     .Where(uc => uc.UserId == userId)
            //     .Include(uc => uc.Course)
            //     .Select(uc => uc.Course.Value)
            //     .ToList()
            //     .ForEach(Console.WriteLine);

        }

        public void ListAssignedUsersCourse(int courseId)
        {
            _context.UserCourses
                .Where(uc => uc.CourseId == courseId)
                .Join(_context.Users, // join with which table
                    uc => uc.UserId, // by what field in UserCourses
                    u => u.Id, // by what field in Users
                    (uc, c) => c.Value )
                .ToList()
                .ForEach(Console.WriteLine);
            
            // TODO: Discuss this with Mykola
            // or this: 

            // _context.UserCourses
            //     .Where(uc => uc.CourseId == courseId)
            //     .Include(uc => uc.User)
            //     .Select(uc => uc.User.Value)
            //     .ToList()
            //     .ForEach(Console.WriteLine);
        }

    }
}