using StudentCRM.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentCRM.ViewModel.StudentResult;

namespace StudentCRM.Service.Contracts
{
    public interface IStudentResultService : IGenericService<StudentResult>
    {
        Task<ShowResults> GetStudentsResult(ShowResults model);
        Task<bool> CheckStudentIdAndCourseIdInTerm(int studentId, int courseId, int termId);
        Task<ShowStudentInfoResult> GetResultsForStudent(int id);
    }
}
