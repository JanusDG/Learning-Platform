using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace LearningPlatform.Models
{
    public class BaseEntityIdValue<T>{
        [Key]
        public int Id { get; set; }
        [Required]
        public T Value { get; set; }
    }

    public class User : BaseEntityIdValue<string>
    {
        public ICollection<UserCourse> UserCourses { get; set; }
    }

    public class Course : BaseEntityIdValue<string>
    {
        public ICollection<UserCourse> UserCourses { get; set; }
    }

    public class UserCourse
    {
        public int UserId { get; set; }
        public User User { get; set; }

        public int CourseId { get; set; }
        public Course Course { get; set; }
    }

}