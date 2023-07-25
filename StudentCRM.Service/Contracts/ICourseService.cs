using StudentCRM.Data.Entities;
using StudentCRM.ViewModel.Course;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentCRM.Service.Contracts;

public interface ICourseService : IGenericService<Course>
{
    Task<ShowCoursesViewModel> GetCourses(ShowCoursesViewModel model);
    Task<EditCourse> GetForEdit(int Id); 
    Dictionary<int, string> GetCourseToShowInSelectBox();
}