using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentCRM.Data.Entities;

[Table("Student")]
[Index(nameof(StudentCode), IsUnique = true)]
[Index(nameof(StudentNumber), IsUnique = true)]

public class Student
{
    [Key]
    public int Id { get; set; }

    [Required]

    public string FirstName { get; set; }
    [Required]

    public string LastName { get; set; }

    [Required]
    public long StudentCode { get; set; }
    
    [Required]
    public long StudentNumber { get; set; }

    [NotMapped]
    public string FullName => $"{FirstName} {LastName}";


   // public ICollection<StudentResult> StudentResults { get; set; } = new List<StudentResult>();

}