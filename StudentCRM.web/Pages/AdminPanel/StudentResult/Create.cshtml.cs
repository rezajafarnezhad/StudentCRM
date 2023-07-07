using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StudentCRM.Data.ApplicationDataBaseContext;
using StudentCRM.Data.Entities;
using StudentCRM.Service.Contracts;
using StudentCRM.ViewModel.StudentResult;
using StudentCRM.web.Common;

namespace StudentCRM.web.Pages.AdminPanel.StudentResult;

public class CreateModel : PageBase
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IStudentResultService _studentResultService;
    private readonly ICourseService _courseService;
    private readonly ItermService _termService;

   [BindProperty(SupportsGet =true)]
    public CreateResult CreateResult { get; set; } = new CreateResult();
    public CreateModel(ItermService termService, ICourseService courseService, IStudentResultService studentResultService, IUnitOfWork unitOfWork)
    {
        _termService = termService;
        _courseService = courseService;
        _studentResultService = studentResultService;
        _unitOfWork = unitOfWork;
    }

    public void OnGet()
    {
        var Courses = _courseService.GetCourseToShowInSelectBox();
        CreateResult.Courses = Courses.CreateSelectListItem();

        var Terms = _termService.GetTermsToShowInSelectBox();
        CreateResult.Terms = Terms.CreateSelectListItem();
    }

    public async Task<IActionResult> OnPost(CreateResult CreateResult)
    {
        if (!ModelState.IsValid)
        {
            return Json(new JsonResultOperation(false, "اطلاعات به درستی وارد شود"));
        }

        var _StudentResult = new Data.Entities.StudentResult()
        {
            Code= CreateResult.Code,
            CourseId= CreateResult.CourseId,
            TermId= CreateResult.TermId,
            FullName = CreateResult.FullName,
            Description = CreateResult.Description,
            Score= CreateResult.Score,
            Status= CreateResult.Status,
            StudentNumber= CreateResult.StudentNumber,
        };

        await _studentResultService.AddAsync(_StudentResult);
        await _unitOfWork.SaveChangesAsync();
        return Json(new JsonResultOperation(true,"با موفقیت  ثبت شد")
        {
            Data= "/AdminPanel/StudentResult"
        });
    }
}