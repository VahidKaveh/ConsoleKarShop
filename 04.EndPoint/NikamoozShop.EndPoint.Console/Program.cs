using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using NikamoozShop.Infrastructures.EF;
using NikamozzShop.Domain.Entites;

namespace NikamoozShop.EndPoint.Console
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var builder = new DbContextOptionsBuilder();
            builder.UseSqlServer(@"server=(localdb)\ProjectsV13;database=NikamoozShopDb;integrated security=true");
            using (var context = new NikamoozStoreContext(builder.Options))
            {
                // EgerLoading(context);
                //ServerVsClient(context);
                //StateCheck(context);
                GraphInsert(context);

                //Update(context);


                context.SaveChanges();
            }
        }

        private static void Update(NikamoozStoreContext context)
        {
            var teacher = context.Teachers.FirstOrDefault(c => c.TeacherId == 1);

            if (teacher != null) teacher.LastName = "Vahid Kaveh";
        }

        private static void GraphInsert(NikamoozStoreContext context)
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

        private static void StateCheck(NikamoozStoreContext context)
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

        private static void ServerVsClient(NikamoozStoreContext context)
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

        private static void EgerLoading(NikamoozStoreContext context)
        {
            var listCourse = context.Courses.Include(c => c.Comments).Include(c => c.CourseTeachers)
                .ThenInclude(c => c.Teacher).ToList();
        }
    }
}