using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StudentCRM.Service.Contracts;
using StudentCRM.ViewModel.StudentResult;
using StudentCRM.web.Common;
using Newtonsoft.Json;
using System.Text.Json;
using Newtonsoft.Json.Linq;

namespace StudentCRM.web.Pages.StudentResult;

public class IndexModel : PageBase
{

    private readonly IStudentResultService _studentResultService;
    private readonly IStudentService _studentService;
    public IndexModel(IStudentResultService studentResultService, IStudentService studentService)
    {
        _studentResultService = studentResultService;
        _studentService = studentService;
    }


    [BindProperty()]
    public ResultViewModel Result { get; set; }

    public void OnGet()
    {
    }

    public async Task<IActionResult> OnPost()
    {
        if (!ModelState.IsValid)
        {
            return Json(new JsonResultOperation(false, "اطلاعات به درستی وارد شود"));
        }

        var id = await _studentService.GetStudentId(Result.StudentNumber, Result.Code);
        if (id <0)
            return Json(new JsonResultOperation(false, "اطلاعات وازد شده اشتباه است"));


        return Json(new JsonResultOperation(true, "در حال انتقال به صفحه نتیجه")
        {
           Data = id
        });
    }

    public  async Task<IActionResult> OnGetShowResult(int studentId)
    {
        if(studentId < 0)
            return Json(new JsonResultOperation(false, "اطلاعات وازد شده اشتباه است"));

        var resultInSite = await _studentResultService.GetResultsForStudent(studentId);
        return Partial("ResultShow", resultInSite);
    }
}