using StudentCRM.Data.Entities;
using StudentCRM.ViewModel.term;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentCRM.Service.Contracts;

public interface ItermService : IGenericService<Term>
{
    Task<ShowtermsViewModel> GetTerms(ShowtermsViewModel model);

    Task<EditTerm> GetForEdit(int Id);
    Dictionary<int, string> GetTermsToShowInSelectBox();
}