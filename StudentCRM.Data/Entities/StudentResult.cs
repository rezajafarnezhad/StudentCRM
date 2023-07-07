using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;


namespace StudentCRM.Data.Entities;


[Table("StudentResult")]
[Index(nameof(Code), IsUnique = true)]
[Index(nameof(StudentNumber), IsUnique = true)]
public class StudentResult
{
    [Key]
    public int Id { get; set; }
    public int CourseId { get; set; }
    public int TermId { get; set; }

    [Required]
    [MaxLength(50)]
    public string FullName { get; set; }

    [Required]
    [MaxLength(20)]
    public string StudentNumber { get; set; }

    [Required]
    [MaxLength(6)]
    public string Code { get; set; }

    [Required]
    public float Score { get; set; }

    public string Description { get; set; }
    public Status Status { get; set; }

    [ForeignKey(nameof(CourseId))]
    public Course Cours { get; set; }
    [ForeignKey(nameof(TermId))]
    public Term Term { get; set; }
}
public enum Status
{
    [Display(Name = "قبول")]
    accept,

    [Display(Name = "مردود")]
    rejected
}