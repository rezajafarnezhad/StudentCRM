using System.ComponentModel.DataAnnotations;

namespace StudentCRM.ViewModel.StudentResult;

public class ResultViewModel
{
    [Required(ErrorMessage ="کد دانشجویی وارد شود")]
    [Display(Name ="کد دانشجویی")]
    [Range(1,int.MaxValue,ErrorMessage ="کد دانشجویی صحیح وارد شود")]
    public long StudentNumber { get; set; }



    [Required(ErrorMessage = "کد پیگیری وارد شود")]
    [Display(Name = "کد پیگیری")]
    [Range(1, int.MaxValue, ErrorMessage = "کد پیگیری صحیح وارد شود")]
    public long Code { get; set; }
}

public class ShowStudentResultInSite
{
    public string TermName { get; set; }
    public string CourseName { get; set; }
    public float Score { get; set; }
    public string Status { get; set; }
    public string Description { get; set; }

}

public class ShowStudentInfoResult
{
    public List<ShowStudentResultInSite> results { get; set; } = new List<ShowStudentResultInSite>();
    public long Number { get; set; }
    public long Code { get; set; }
    public string FullName { get; set; }

}