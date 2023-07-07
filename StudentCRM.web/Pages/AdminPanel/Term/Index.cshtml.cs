using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StudentCRM.Data.ApplicationDataBaseContext;
using StudentCRM.Data.Entities;
using StudentCRM.Service.Contracts;
using StudentCRM.ViewModel.term;
using StudentCRM.web.Common;

namespace StudentCRM.web.Pages.AdminPanel.Term;

public class IndexModel : PageBase
{

    private readonly ItermService _termService;
    private readonly IUnitOfWork _unitOfWork;

    public IndexModel(ItermService termService, IUnitOfWork unitOfWork)
    {
        _termService = termService;
        _unitOfWork = unitOfWork;
    }


    [BindProperty(SupportsGet = true)]
    public ShowtermsViewModel Terms { get; set; } = new ShowtermsViewModel();
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

        return Partial("_List", await _termService.GetTerms(Terms));
    }


    public IActionResult OnGetAdd()
    {
        return Partial("Add");
    }

    public async Task<IActionResult> OnPostAdd(CreateTerm model)
    {
        if (!ModelState.IsValid)
        {
            return Json(new JsonResultOperation(false, "لطفا مقادیر را به درستی وارد نمایید")
            {
                Data = ModelState.GetModelStateErrors()
            });
        }

        var _term = new Data.Entities.Term()
        {
            Name = model.Name,
        };
        await _termService.AddAsync(_term);
        await _unitOfWork.SaveChangesAsync();
        return Json(new JsonResultOperation(true, "ترم با موفقیت ثبت شد"));
    }


    public async Task<IActionResult> OnGetEdit(int Id)
    {
        var _term = await _termService.GetForEdit(Id);
        if (_term is null)
        {
            return Json(new JsonResultOperation(false, "اطلاعات یافت نشد")
            {
               
            });
        }

        return Partial("Edit",_term);
    }

    public async Task<IActionResult> OnPostEdit(EditTerm model)
    {
        if (!ModelState.IsValid)
        {
            return Json(new JsonResultOperation(false, "لطفا مقادیر را به درستی وارد نمایید")
            {
                Data = ModelState.GetModelStateErrors()
            });
        }

       

        var _term = await _termService.FindAsync(model.Id);
        if (_term is null)
            return Json(new JsonResultOperation(false, "اطلاعات یافت نشد"));

        _term.Name = model.Name;
        _termService.Update(_term);
        await _unitOfWork.SaveChangesAsync();
        return Json(new JsonResultOperation(true, "اتجام شد"));

    }

}