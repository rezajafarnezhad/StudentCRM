using System.ComponentModel.DataAnnotations;

namespace StudentCRM.ViewModel.StudentResult;

public class ResultViewModel
{
    [Required(ErrorMessage ="کد دانشجویی وارد شود")]
    [Display(Name ="کد دانشجویی")]
    [MaxLength(20,ErrorMessage ="کد دانشجویی صحیح وارد شود")]
    public string StudentNumber { get; set; }



    [Required(ErrorMessage = "کد پیگیری وارد شود")]
    [Display(Name = "کد پیگیری")]
    [MaxLength(6, ErrorMessage = "کد پیگیری صحیح وارد شود")]
    public string Code { get; set; }
}

public class ShowStudentResultInSite
{
    public string StudentNumber { get; set; }
    public string FullName { get; set; }
    public string TermName { get; set; }
    public string CourseName { get; set; }
    public float Score { get; set; }
    public string Status { get; set; }
    public string Description { get; set; }

}