using System;
using System.Collections.Generic;

namespace NikamozzShop.Domain.Entites
{
    public class Course
    {
        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int SessionCount { get; set; }
        public double Price { get; set; }
        public ICollection<CourseTeacher> CourseTeachers { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public Discount MyDiscount { get; set; }
    }
}