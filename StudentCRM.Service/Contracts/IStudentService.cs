using StudentCRM.Data.Entities;
using StudentCRM.ViewModel.Student;

namespace StudentCRM.Service.Contracts;

public interface IStudentService : IGenericService<Student>
{
    Task<ShowStudentsViewModel> GetStudents(ShowStudentsViewModel model);
    Task<EditStudent> GetForEdit(int Id);
    Task<StudentInfo> GetInfo(int id);
    Task<int> GetStudentId(long number, long code);
}