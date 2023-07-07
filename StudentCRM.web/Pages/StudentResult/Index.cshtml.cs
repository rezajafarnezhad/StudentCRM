using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StudentCRM.Service.Contracts;
using StudentCRM.ViewModel.StudentResult;
using StudentCRM.web.Common;

namespace StudentCRM.web.Pages.StudentResult;

public class IndexModel : PageBase
{

    private readonly IStudentResultService _studentResultService;

    public IndexModel(IStudentResultService studentResultService)
    {
        _studentResultService = studentResultService;
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

        var res = await _studentResultService.GetResultForSite(Result.StudentNumber, Result.Code);
        if (res is null)
            return Json(new JsonResultOperation(false, "اطلاعات وازد شده اشتباه است"));


        return Json(new JsonResultOperation(true, "در حال انتقال به صفخه نتیجه")
        {
            Data= res
        });
    }

    public  IActionResult OnGetShowResult(ShowStudentResultInSite resultInSite)
    {
        return Partial("ResultShow", resultInSite);
    }
}