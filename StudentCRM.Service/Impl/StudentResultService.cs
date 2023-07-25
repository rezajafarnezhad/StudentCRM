using Microsoft.EntityFrameworkCore;
using StudentCRM.Data.ApplicationDataBaseContext;
using StudentCRM.Data.Entities;
using StudentCRM.Service.Contracts;
using StudentCRM.ViewModel.StudentResult;

namespace StudentCRM.Service.Impl;

public class StudentResultService : GenericService<StudentResult>, IStudentResultService
{
    private readonly DbSet<StudentResult> _studentResult;
    private readonly IStudentService _studentService;
    public StudentResultService(IUnitOfWork uow, IStudentService studentService) : base(uow)
    {
        _studentService = studentService;
        _studentResult = uow.Set<StudentResult>();
    }

    public async Task<ShowResults> GetStudentsResult(ShowResults model)
    {

        var studentsResult = _studentResult.AsNoTracking().AsQueryable();

        if (!string.IsNullOrWhiteSpace(model.SearchResult.FullName))
            studentsResult = studentsResult.Where(c => c.Student.FullName.Contains(model.SearchResult.FullName));

        if (model.SearchResult.Code != null)
            studentsResult = studentsResult.Where(c => c.Student.StudentCode == model.SearchResult.Code);


        if (model.SearchResult.StudentNumber != null)
            studentsResult = studentsResult.Where(c => c.Student.StudentNumber == model.SearchResult.StudentNumber);

        if (model.SearchResult.CourseId > 0)
            studentsResult = studentsResult.Where(c => c.CourseId == model.SearchResult.CourseId);

        if (model.SearchResult.TermId > 0)
            studentsResult = studentsResult.Where(c => c.TermId == model.SearchResult.TermId);


        if (model.SearchResult.Status != StatusSearch.All)
        {
            if (model.SearchResult.Status == StatusSearch.accept)
            {
                studentsResult = studentsResult.Where(c => c.Status == Status.accept);

            }
            else
            {
                studentsResult = studentsResult.Where(c => c.Status == Status.rejected);

            }
        }
        

        var paginationResult = await GenericPagination(studentsResult, model.Pagination);


        return new ShowResults
        {
            Results = await paginationResult.Query.Select(c => new ShowResult()
            {
                Id = c.Id,
                CourseName = c.Cours.Name,
                TermName = c.Term.Name,
                Status = c.Status,
                Score = c.Score,
                Code=c.Student.StudentCode,
                StudentNumber = c.Student.StudentNumber,
                FullName = c.Student.FullName,

            }).ToListAsync(),

            Pagination = paginationResult.Pagination
        };
    }

    public async Task<bool> CheckStudentIdAndCourseIdInTerm(int studentId, int courseId, int termId)
    {
        return await _studentResult.AnyAsync(c => c.StudentId == studentId && c.CourseId == courseId && c.TermId == termId);
    }

    public async Task<ShowStudentInfoResult> GetResultsForStudent(int id)
    {
        
        var studentInfo = await _studentService.GetInfo(id);
        return new ShowStudentInfoResult()
        {
            FullName = studentInfo.Fullname,
            Number=studentInfo.Number,
            Code=studentInfo.Code,
            results = await _studentResult.Where(c => c.StudentId == id)
                .Select(c => new ShowStudentResultInSite()
                {
                    CourseName = c.Cours.Name,
                    Description = c.Description,
                    Score = c.Score,
                    TermName = c.Term.Name,
                    Status = c.Status.ToString(),
                })
                .ToListAsync()
        };

    }

   
}