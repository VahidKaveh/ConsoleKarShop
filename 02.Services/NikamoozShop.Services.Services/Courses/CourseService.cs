using NikamoozShop.Infrastructures.EF;
using System.Collections.Generic;
using System.Linq;


namespace NikamoozShop.Services.Services.Courses
{
    public class CourseService
    {
        private readonly NikamoozStoreContext _context;

        public CourseService(NikamoozStoreContext context)
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