using ConsoleKarShop.Domain.Entites;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleKarShop.Services.Services.Courses
{
    public static class CourseToDto
    {
        public static IQueryable<CourseDto> ToCourseDto(this IQueryable<Course> input)
        {
            return input.Select(c => new CourseDto
            {
                CourseId = c.CourseId,
                CourseName = c.CourseName,
                Description = c.MyDiscount.Description,
                NewValue = c.MyDiscount.NewValue,
                Price = c.Price,
                Rate = c.Comments.Average(d => d.Vote)
            });
        }

        public static IQueryable<CourseDto> SearchCourse(this IQueryable<CourseDto> input, string courseName)
        {
            return input.Where(c => c.CourseName.Contains(courseName));
        }
        public enum SortOn
        {
            Id,
            Rate,
            Price
        }

        public static IQueryable<CourseDto> Sort(this IQueryable<CourseDto> input, SortOn sortOn)
        {
            switch (sortOn)
            {
                case SortOn.Rate:
                    return input.OrderBy(c => c.Rate);
                case SortOn.Price:
                    return input.OrderBy(c => c.Price);
            }
            return input.OrderBy(c => c.CourseId);
        }

        public static IQueryable<T> Pagination<T>(this IQueryable<T> input, int pageSize, int pageIndex)
        {
            return pageIndex > 0 ? input.Skip(pageIndex * pageSize).Take(pageSize) : input.Take(pageSize);
        }

    }
}