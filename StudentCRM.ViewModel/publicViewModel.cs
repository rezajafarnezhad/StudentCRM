
using System.ComponentModel.DataAnnotations;

namespace StudentCRM.ViewModel;

public enum PageCount
{
    [Display(Name = "10 سطر")]
    Ten,
    [Display(Name = "25 سطر")]

    TwentyFive,
    [Display(Name = "50 سطر")]

    Fifty,
    [Display(Name = "100 سطر")]

    Hundred,
}

public class PaginationViewModel
{
  
    public int CurrentPage { get; set; } = 1;

   
    public PageCount PageCount { get; set; } = PageCount.Ten;

    public int PagesCount { get; set; }

    public int StartPage => CurrentPage - 3 < 1 ? 1 : CurrentPage - 3;

    public int EndPage => CurrentPage + 3 > PagesCount ? PagesCount : CurrentPage + 3;
}

public class CommonPaginationViewModel
{
    public int CurrentPage { get; set; } = 1;

    public int PagesCount { get; set; }

    public int StartPage => CurrentPage - 3 < 1 ? 1 : CurrentPage - 3;

    public int EndPage => CurrentPage + 3 > PagesCount ? PagesCount : CurrentPage + 3;

    public string FunctionName { get; set; }
}

public class PaginationResultViewModel<T>
{
    public IQueryable<T> Query { get; set; }

    public PaginationViewModel Pagination { get; set; }
}

public class CommonPaginationResultViewModel<T>
{
    public IQueryable<T> Query { get; set; }

    public CommonPaginationViewModel Pagination { get; set; }
}