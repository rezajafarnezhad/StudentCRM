using Microsoft.EntityFrameworkCore;
using StudentCRM.Data.ApplicationDataBaseContext;
using StudentCRM.Data.Entities;
using StudentCRM.Service.Contracts;
using StudentCRM.ViewModel.StudentResult;

namespace StudentCRM.Service.Impl;

public class StudentResultService : GenericService<StudentResult>, IStudentResultService
{
    private readonly DbSet<StudentResult> _studentResult;
    public StudentResultService(IUnitOfWork uow) : base(uow)
    {
        _studentResult = uow.Set<StudentResult>();
    }

    public async Task<ShowResults> GetStudentsResult(ShowResults model)
    {

        var studentsResult = _studentResult.AsNoTracking().AsQueryable();

        if (!string.IsNullOrWhiteSpace(model.SearchResult.FullName))
            studentsResult = studentsResult.Where(c => c.FullName.Contains(model.SearchResult.FullName));

        if (!string.IsNullOrWhiteSpace(model.SearchResult.Code))
            studentsResult = studentsResult.Where(c => c.Code == model.SearchResult.Code);


        if (!string.IsNullOrWhiteSpace(model.SearchResult.StudentNumber))
            studentsResult = studentsResult.Where(c => c.StudentNumber == model.SearchResult.StudentNumber);

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
                StudentNumber = c.StudentNumber,
                Code = c.Code,
                FullName = c.FullName,
                CourseName = c.Cours.Name,
                TermName = c.Term.Name,
                Status = c.Status,
                Score = c.Score,

            }).ToListAsync(),

            Pagination = paginationResult.Pagination
        };
    }

    public async Task<ShowStudentResultInSite> GetResultForSite(string studentNumber, string Code)
    {
        var res = await _studentResult
            .Where(c => c.StudentNumber == studentNumber)
            .Where(c => c.Code == Code)
            .Select(c=> new ShowStudentResultInSite()
            {
                TermName = c.Term.Name,
                CourseName=c.Cours.Name,
                FullName=c.FullName,
                Description = c.Description,
                Score = c.Score,
                Status=c.Status.ToString(),
                StudentNumber=c.StudentNumber,
            })
            .SingleOrDefaultAsync();

        return res;

    }
}