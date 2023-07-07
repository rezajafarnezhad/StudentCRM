using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using StudentCRM.Data.Entities;


namespace StudentCRM.ViewModel.StudentResult
{
    public class ShowResults
    {
        public SearchResult SearchResult { get; set; } = new();
        public List<ShowResult> Results { get; set; } = new();
        public PaginationViewModel Pagination { get; set; } = new();
    }

    public class ShowResult
    {
        public int Id { get; set; }

        [Display(Name ="نام درس")]
        public string CourseName { get; set; }

        [Display(Name = "نام ترم")]

        public string TermName { get; set; }

        [Display(Name ="نام و فامیلی")]

        public string FullName { get; set; }

        [Display(Name ="شماره دانشجویی")]

        public string StudentNumber { get; set; }

        [Display(Name ="کد پیگیری")]

        public string Code { get; set; }
        
        [Display(Name ="نمره")]

        public float Score { get; set; }

        [Display(Name ="نتیجه")]

        public Status Status { get; set; }
    }

    public class SearchResult
    {
        [Display(Name = "درس")]
        public int? CourseId { get; set; }
        public List<SelectListItem> Courses { get; set; } = new();

        [Display(Name = "ترم")]

        public int? TermId { get; set; }
        public List<SelectListItem> Terms { get; set; } = new();


        [Display(Name = "نام و فامیلی")]

        public string FullName { get; set; }

        [Display(Name = "شماره دانشجویی")]

        public string StudentNumber { get; set; }

        [Display(Name = "کد پیگیری")]

        public string Code { get; set; }

        [Display(Name = "نتیجه")]
        public StatusSearch Status { get; set; }
    }
    public enum StatusSearch
    {
        [Display(Name = "همه")]
        All,

        [Display(Name = "قبول")]
        accept,

        [Display(Name = "مردود")]
        rejected
    }

    public class CreateResult
    {
        [Display(Name = "درس")]
        [Required(ErrorMessage = "الزامی است")]
        [Range(0, int.MaxValue, ErrorMessage = "درست وارد شود")]

        public int CourseId { get; set; }
        public List<SelectListItem> Courses { get; set; } = new();

        [Display(Name = "ترم")]
        [Required(ErrorMessage = "الزامی است")]
        [Range(0, int.MaxValue, ErrorMessage = "درست وارد شود")]

        public int TermId { get; set; }
        public List<SelectListItem> Terms { get; set; } = new();


        [Display(Name = "نام و فامیلی")]
        [Required(ErrorMessage = "الزامی است")]

        public string FullName { get; set; }

        [Display(Name = "شماره دانشجویی")]
        [Required(ErrorMessage = "الزامی است")]
        [MaxLength(20, ErrorMessage = "حداقل 6 کاراکتر")]


        public string StudentNumber { get; set; }

        [Display(Name = "کد پیگیری")]
        [Required(ErrorMessage = "الزامی است")]
        [MaxLength(6,ErrorMessage ="حداقل 6 کاراکتر")]
        public string Code { get; set; }
        [Required(ErrorMessage = "الزامی است")]

        [Display(Name = "نتیجه")]
        
        public Status Status { get; set; }

        [Display(Name = "نمره")]
        [Required(ErrorMessage = "الزامی است")]
        [Range(0,100,ErrorMessage ="حدافل 0 تا 100")]
        public float Score { get; set; }
        public string Description { get; set; }

    }
}
