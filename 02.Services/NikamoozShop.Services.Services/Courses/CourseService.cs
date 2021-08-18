using ConsoleKarShop.Infrastructures.EF;
using System.Collections.Generic;
using System.Linq;


namespace ConsoleKarShop.Services.Services.Courses
{
    public class CourseService
    {
        private readonly ConsoleKarStoreContext _context;

        public CourseService(ConsoleKarStoreContext context)
        {
            _context = context;
        }

        public List<CourseDto> SearchCourse(string searchText, CourseToDto.SortOn sortOn, int pageIndex, int pageSize)
        {
            return _context.Courses.ToCourseDto()
                .Sort(sortOn)
                .SearchCourse(searchText)
                .Pagination(pageSize, pageIndex)
                .ToList();
        }
    }
}