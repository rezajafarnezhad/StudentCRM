using Microsoft.EntityFrameworkCore;
using StudentCRM.Data.ApplicationDataBaseContext;
using StudentCRM.Data.Entities;
using StudentCRM.Service.Contracts;
using StudentCRM.ViewModel.Course;
using StudentCRM.ViewModel.term;
using System.Security.AccessControl;

namespace StudentCRM.Service.Impl;

public class CourseService : GenericService<Course>, ICourseService
{
    private readonly DbSet<Course> _course;
    public CourseService(IUnitOfWork uow) : base(uow)
    {
        _course = uow.Set<Course>();
    }


    public async Task<EditCourse> GetForEdit(int Id)
    {
        return await _course.Select(c => new EditCourse()
        {
            Id = c.Id,
            Name = c.Name,
            Unit = c.Unit,

        }).SingleOrDefaultAsync(c => c.Id == Id);


    }

    public Dictionary<int, string> GetCourseToShowInSelectBox()
    {
        return _course.ToDictionary(c => c.Id, c => c.Name);
    }

    public async Task<ShowCoursesViewModel> GetCourses(ShowCoursesViewModel model)
    {
        var _courses = _course.AsNoTracking().AsQueryable();

        if (!string.IsNullOrWhiteSpace(model.SearchCourse.Name))
            _courses = _courses.Where(c => c.Name.Contains(model.SearchCourse.Name));

        if (model.SearchCourse.Unit > 0)
            _courses = _courses.Where(c => c.Unit == model.SearchCourse.Unit);

        var paginationResult = await GenericPagination(_courses, model.Pagination);

        return new ShowCoursesViewModel()
        {
            ShowCourses = await paginationResult.Query.Select(c => new ShowCourse()
            {
                Id = c.Id,
                Name = c.Name,
                Unit = c.Unit,
            }).ToListAsync(),

            Pagination = paginationResult.Pagination


        };


    }

}