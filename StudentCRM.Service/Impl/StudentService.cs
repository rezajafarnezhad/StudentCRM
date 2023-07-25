using Microsoft.EntityFrameworkCore;
using StudentCRM.Data.ApplicationDataBaseContext;
using StudentCRM.Data.Entities;
using StudentCRM.Service.Contracts;
using StudentCRM.ViewModel.Student;
using System.Net;

namespace StudentCRM.Service.Impl;

public class StudentService : GenericService<Student> , IStudentService 
{
    private readonly DbSet<Student> _student;
    public StudentService(IUnitOfWork uow) : base(uow)
    {
        _student = uow.Set<Student>();
    }


    public async Task<ShowStudentsViewModel> GetStudents(ShowStudentsViewModel model)
    {
        var _students =  _student.AsNoTracking().AsQueryable();

        if (!string.IsNullOrWhiteSpace(model.SearchStudent.FullName))
            _students = _students.Where(c => c.FullName.Contains(model.SearchStudent.FullName));

        if (model.SearchStudent.StudentCode != null)
            _students = _students.Where(c => c.StudentCode == model.SearchStudent.StudentCode);

        if (model.SearchStudent.StudentNumber !=null)
            _students = _students.Where(c => c.StudentNumber == model.SearchStudent.StudentNumber);
        
        var paginationResult = await GenericPagination(_students, model.Pagination);

        return new ShowStudentsViewModel()
        {
            Students = await paginationResult.Query.Select(c=> new StudentViewModel()
            {
                Id = c.Id,
                FirstName = c.FirstName,
                LastName = c.LastName,
                FullName =c.FullName,
                StudentCode = c.StudentCode,
                StudentNumber = c.StudentNumber,
            }).ToListAsync(),

            Pagination = paginationResult.Pagination

        };
    }

    public async Task<EditStudent> GetForEdit(int Id)
    {
        var data = await _student.Select(c => new EditStudent()
        {
            Id = c.Id,
            FirstName = c.FirstName,
            LastName = c.LastName,
            StudentCode= c.StudentCode,
            StudentNumber = c.StudentNumber,

        }).SingleAsync(c=>c.Id == Id);

        return data;
    }

    public async Task<StudentInfo> GetInfo(int id)
    {
        var data = await _student.Select(c => new StudentInfo()
        {
            Id = c.Id,
            Fullname = c.FullName,
            Code = c.StudentCode,
            Number = c.StudentNumber,

        }).SingleOrDefaultAsync(c => c.Id == id);
        
        return data;
    }

    public async Task<int> GetStudentId(long number, long code)
    {
        var id = await _student.Where(c => c.StudentNumber == number && c.StudentCode == code).Select(c=>c.Id).SingleAsync();

        return id;
    }
}   