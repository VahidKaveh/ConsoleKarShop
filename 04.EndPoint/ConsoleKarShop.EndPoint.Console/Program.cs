using System;
using System.Linq;
using ConsoleKarShop.Domain.Entites;
using ConsoleKarShop.Infrastructures.EF;
using Microsoft.EntityFrameworkCore;

namespace ConsoleKarShop.EndPoint.Console
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var builder = new DbContextOptionsBuilder();
            builder.UseSqlServer(@"server=(localdb)\MSSQLLocalDB;database=ConsoleKarShopDb;integrated security=true");
            using (var context = new ConsoleKarStoreContext(builder.Options))
            {
                // EgerLoading(context);
                //ServerVsClient(context);
                //StateCheck(context);
                GraphInsert(context);

                //Update(context);


                context.SaveChanges();
            }
        }

        private static void Update(ConsoleKarStoreContext context)
        {
            var teacher = context.Teachers.FirstOrDefault(c => c.TeacherId == 1);

            if (teacher != null) teacher.LastName = "Vahid Kaveh";
        }

        private static void GraphInsert(ConsoleKarStoreContext context)
        {
            var course = new Course
            {
                CourseName = "FullStack Core",
                StartDate = DateTime.Now.AddDays(30),
                EndDate = DateTime.Now.AddDays(100),
                Price = 2000,
                MyDiscount = new Discount
                {
                    Description = "Takhfif Shoro Dore",
                    NewValue = 1700
                }
            };
            context.Add(course);
        }

        private static void StateCheck(ConsoleKarStoreContext context)
        {
            var teacher = new Teacher
            {
                FirstName = "Mohammad",
                LastName = "Kaveh"
            };
            var state01 = context.Entry(teacher).State;

            context.Teachers.Add(teacher);

            var state02 = context.Entry(teacher).State;

            context.SaveChanges();
            var state03 = context.Entry(teacher).State;
        }

        private static void ServerVsClient(ConsoleKarStoreContext context)
        {
            var result = context.Courses.Select(c => new
            {
                Course = c.CourseName,
                startDate = c.StartDate,
                CommentsCount = c.Comments.Count(),
                Comments = string.Join(",", c.Comments.Select(com => com.Text))
            }).FirstOrDefault();
            System.Console.WriteLine();
        }

        private static void EgerLoading(ConsoleKarStoreContext context)
        {
            var listCourse = context.Courses.Include(c => c.Comments).Include(c => c.CourseTeachers)
                .ThenInclude(c => c.Teacher).ToList();
        }
    }
}