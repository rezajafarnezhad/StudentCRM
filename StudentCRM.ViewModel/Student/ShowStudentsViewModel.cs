using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentCRM.ViewModel.Student;

public class ShowStudentsViewModel
{

    public List<StudentViewModel> Students { get; set; } = new();
    public PaginationViewModel Pagination { get; set; } = new();
    public SearchStudentViewModel SearchStudent { get; set; }
}

public class SearchStudentViewModel
{
    [Display(Name ="نام و نام خانوادگی")]
    public string FullName { get; set; }

    [Display(Name ="کد ملی")]
    public long? StudentCode { get; set; }

    [Display(Name ="شماره دانشجویی")]
    public long? StudentNumber { get; set; }
}

public class StudentViewModel
{
    [Required]
    public int Id { get; set; }

    [Required]
    public string FirstName { get; set; }
    [Required]

    public string LastName { get; set; }


    public string FullName { get; set; }

    [Required]
    public long StudentCode { get; set; }

    [Required]
    public long StudentNumber { get; set; }
}

public class CreateStudent
{
  

    [Required(ErrorMessage ="الزامی است")]
    [Display(Name ="نام کوچک")]
    public string FirstName { get; set; }
    [Required(ErrorMessage = "الزامی است")]

    [Display(Name = "نام خانوادگی")]

    public string LastName { get; set; }

    [Required(ErrorMessage = "الزامی است")]
    [Display(Name ="کد ملی")]

    public long StudentCode { get; set; }

    [Required(ErrorMessage = "الزامی است")]
    [Display(Name = "شماره دانشجویی")]

    public long StudentNumber { get; set; }

}

public class EditStudent : CreateStudent
{

    public int Id { get; set; }
}

public class StudentInfo
{
    public int Id { get; set; }
    public string Fullname { get; set; }
    public long Code { get; set; }
    public long Number { get; set; }
}