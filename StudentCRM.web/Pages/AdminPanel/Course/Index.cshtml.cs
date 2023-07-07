using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StudentCRM.Data.ApplicationDataBaseContext;
using StudentCRM.Data.Entities;
using StudentCRM.Service.Contracts;
using StudentCRM.Service.Impl;
using StudentCRM.ViewModel.Course;
using StudentCRM.web.Common;

namespace StudentCRM.web.Pages.AdminPanel.Course
{
    public class IndexModel : PageBase
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly ICourseService _courseService;
        public IndexModel(IUnitOfWork unitOfWork, ICourseService courseService)
        {
            _unitOfWork = unitOfWork;
            _courseService = courseService;
        }


        [BindProperty(SupportsGet =true)]
        public ShowCoursesViewModel Courses { get; set; } = new();

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnGetGetDataTableAsync()
        {
            if (!ModelState.IsValid)
            {
                return Json(new JsonResultOperation(false, "لطفا مقادیر را به درستی وارد نمایید")
                {
                    Data = ModelState.GetModelStateErrors()
                });
            }

            return Partial("_List", await _courseService.GetCourses(Courses));
        }


        public async Task<IActionResult> OnGetAdd()
        {
            return Partial("Add");
        }

        public async Task<IActionResult> OnPostAdd(CraeteCourse model)
        {
            if (!ModelState.IsValid)
            {
                return Json(new JsonResultOperation(false, "لطفا مقادیر را به درستی وارد نمایید")
                {
                   
                });
            }

            var _course = new Data.Entities.Course()
            {
                Name = model.Name,
                Unit = model.Unit,
            };

            await _courseService.AddAsync(_course);
            await _unitOfWork.SaveChangesAsync();
            return Json(new JsonResultOperation(true, "با موفقیت ثبت شد"));

        }


        public async Task<IActionResult> OnGetEdit(int Id)
        {
            if(Id<0)
                return Json(new JsonResultOperation(false, "لطفا مقادیر را به درستی وارد نمایید"));

            var _course = await _courseService.GetForEdit(Id);
            if(_course is null)
                return Json(new JsonResultOperation(false, "لطفا مقادیر را به درستی وارد نمایید"));

            return Partial("Edit" , _course);

        }

        public async Task<IActionResult> OnPostEdit(EditCourse model)
        {
            if (!ModelState.IsValid)
            {
                return Json(new JsonResultOperation(false, "لطفا مقادیر را به درستی وارد نمایید")
                {

                });
            }

            var _course = await _courseService.FindAsync(model.Id);
            if(_course is null)
                return Json(new JsonResultOperation(false, "لطفا مقادیر را به درستی وارد نمایید")
                {

                });

            _course.Name = model.Name;
            _course.Unit = model.Unit;
            _courseService.Update(_course);
            await _unitOfWork.SaveChangesAsync();
            return Json(new JsonResultOperation(true, "با موفقیت ویرایش شد"));
        }


    }
}
