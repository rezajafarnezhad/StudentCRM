using Microsoft.AspNetCore.DataProtection.KeyManagement.Internal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StudentCRM.Data.ApplicationDataBaseContext;
using StudentCRM.Data.Entities;
using StudentCRM.Service.Contracts;
using StudentCRM.Service.Impl;
using StudentCRM.ViewModel.Student;
using StudentCRM.web.Common;

namespace StudentCRM.web.Pages.AdminPanel.Students;

public class IndexModel : PageBase
{

    private readonly IStudentService _studentService;
    private readonly IUnitOfWork _unitOfWork;
    public IndexModel(IStudentService studentService, IUnitOfWork unitOfWork)
    {
        _studentService = studentService;
        _unitOfWork = unitOfWork;
    }


    [BindProperty(SupportsGet =true)]
    public ShowStudentsViewModel Students { get; set; } = new ShowStudentsViewModel();

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

        return Partial("_List", await _studentService.GetStudents(Students));
    }

    public async Task<IActionResult> OnGetAdd()
    {
        return Partial("Add");
    }

    public async Task<IActionResult> OnPostAdd(CreateStudent model)
    {
        if (!ModelState.IsValid)
        {
            return Json(new JsonResultOperation(false, "لطفا مقادیر را به درستی وارد نمایید")
            {
              
            });
        }

        var _student = new Student()
        {
            FirstName = model.FirstName,
            LastName = model.LastName,
            StudentCode = model.StudentCode,
            StudentNumber = model.StudentNumber,
        };

        await _studentService.AddAsync(_student);
        await _unitOfWork.SaveChangesAsync();
        return Json(new JsonResultOperation(true, "با موفقیت ثبت شد"));
    }


    public async Task<IActionResult> OnGetEdit(int Id)
    {
        if(Id <0 )
            return Json(new JsonResultOperation(false, "لطفا مقادیر را به درستی وارد نمایید")
            {

            });

        var data = await _studentService.GetForEdit(Id);
        if (data is null)
            return Json(new JsonResultOperation(false, "لطفا مقادیر را به درستی وارد نمایید")
            {

            });

        return Partial("Edit",data);


    }

    public async Task<IActionResult> OnPostEdit(EditStudent model)
    {
        if (!ModelState.IsValid)
        {
            return Json(new JsonResultOperation(false, "لطفا مقادیر را به درستی وارد نمایید")
            {

            });
        }

        var _student = await _studentService.FindAsync(model.Id);
        if(_student is null)
            return Json(new JsonResultOperation(false, "لطفا مقادیر را به درستی وارد نمایید")
            {

            });

        _student.StudentNumber = model.StudentNumber;
        _student.StudentCode = model.StudentCode;
        _student.FirstName = model.FirstName;
        _student.LastName = model.LastName;
        _studentService.Update(_student);
        await _unitOfWork.SaveChangesAsync();
        return Json(new JsonResultOperation(true, "با موفقیت ویرایش شد"));
    }
}