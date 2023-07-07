using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentCRM.ViewModel.Course
{
    public class ShowCoursesViewModel
    {
        public List<ShowCourse> ShowCourses { get; set; } = new();
        public SearchCourse SearchCourse { get; set; } = new();
        public PaginationViewModel Pagination { get; set; } = new();

    }

    public class ShowCourse
    {
       
        public int Id { get; set; }

        [Display(Name = "درس")]
        public string Name { get; set; }
        [Display(Name = "واحد")]
        public byte Unit { get; set; }
    }

    public class SearchCourse
    {
        [Display(Name = "درس")]
        public string Name { get; set; }

        [Range(0,30,ErrorMessage ="واحد به درستی وارد شود")]
        [Display(Name = "واحد")]
        public byte Unit { get; set; }
    }

    public class CraeteCourse
    {
        [Required(ErrorMessage ="الزامی است")]
        [Display(Name="درس")]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required(ErrorMessage = "الزامی است")]
        [Display(Name = "واحد")]

        public byte Unit { get; set; }
    }

    public class EditCourse : CraeteCourse
    {
        public int Id { get; set; }
    }




}
