using System.Collections.Generic;

namespace NikamozzShop.Domain.Entites
{
    public class Teacher    
    {
        public int TeacherId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public ICollection<CourseTeacher> CourseTeachers { get; set; }
        public bool IsDeleted { get; set; }

    }
}