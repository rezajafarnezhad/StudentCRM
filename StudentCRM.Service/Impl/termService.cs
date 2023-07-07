using StudentCRM.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentCRM.Service.Contracts;
using StudentCRM.ViewModel.term;
using Microsoft.EntityFrameworkCore;
using StudentCRM.Data.ApplicationDataBaseContext;

namespace StudentCRM.Service.Impl;

public class termService : GenericService<Term>, ItermService
{
    private readonly DbSet<Term> _terms;
    public termService(IUnitOfWork uow) : base(uow)
    {
        _terms = uow.Set<Term>();
    }

    public async Task<ShowtermsViewModel> GetTerms(ShowtermsViewModel model)
    {

        var aterms = _terms.AsNoTracking().AsQueryable();

        if (!string.IsNullOrWhiteSpace(model.SearchTerm.Name))
            aterms = aterms.Where(c => c.Name.Contains(model.SearchTerm.Name));

        var paginationResult = await GenericPagination(aterms, model.Pagination);


        return new ShowtermsViewModel
        {
            terms = await paginationResult.Query.Select(c => new ShowTermviewModel()
            {
                Id = c.Id,
                Name = c.Name,

            }).ToListAsync(),

            Pagination = paginationResult.Pagination
        };
    }

    public async Task<EditTerm> GetForEdit(int Id)
    {
        return await _terms.Select(c => new EditTerm()
        {
            Id = c.Id,
            Name = c.Name,

        }).SingleOrDefaultAsync(c => c.Id == Id);


    }


    public Dictionary<int, string> GetTermsToShowInSelectBox()
    {
        return _terms.ToDictionary(c => c.Id, c => c.Name);
    }
}