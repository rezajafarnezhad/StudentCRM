using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentCRM.Data.Entities;



[Table("Course")]
public class Course
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(50)]
    public string Name { get; set; }

    [Required]
    public byte Unit { get; set; }

    public ICollection<StudentResult> StudentResults { get; set; } = new List<StudentResult>();

}