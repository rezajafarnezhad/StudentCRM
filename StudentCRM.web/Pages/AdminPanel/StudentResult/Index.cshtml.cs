using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StudentCRM.Data.ApplicationDataBaseContext;
using StudentCRM.Data.Entities;
using StudentCRM.Service.Contracts;
using StudentCRM.Service.Impl;
using StudentCRM.ViewModel.Course;
using StudentCRM.ViewModel.StudentResult;
using StudentCRM.web.Common;

namespace StudentCRM.web.Pages.AdminPanel.StudentResult;

public class IndexModel : PageBase
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IStudentResultService _studentResultService;
    private readonly ICourseService _courseService;
    private readonly ItermService _termService;
    public IndexModel(IUnitOfWork unitOfWork, IStudentResultService studentResultService, ICourseService courseService, ItermService termService)
    {
        _unitOfWork = unitOfWork;
        _studentResultService = studentResultService;
        _courseService = courseService;
        _termService = termService;
    }


    [BindProperty(SupportsGet =true)]
    public ShowResults ShowResults { get; set; } = new();

    public void OnGet()
    {
        var Courses = _courseService.GetCourseToShowInSelectBox();
        ShowResults.SearchResult.Courses = Courses.CreateSelectListItem(firstItemValue: String.Empty);
        
        var Terms = _termService.GetTermsToShowInSelectBox();
        ShowResults.SearchResult.Terms = Terms.CreateSelectListItem(firstItemValue: String.Empty);
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

        return Partial("_List", await _studentResultService.GetStudentsResult(ShowResults));
    }


   


}