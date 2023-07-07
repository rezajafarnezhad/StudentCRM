using System.ComponentModel.DataAnnotations;

namespace StudentCRM.ViewModel.term;

public class ShowtermsViewModel
{
    public List<ShowTermviewModel> terms { get; set; } = new();
    public SearchTermViewModel SearchTerm { get; set; } = new();
    public PaginationViewModel Pagination { get; set; } = new();
}

public class ShowTermviewModel
{
    public int Id { get; set; }

    [Display(Name ="نام ترم")]
    [MaxLength(50)]
    public string Name { get; set; }

}

public class SearchTermViewModel : ShowTermviewModel
{

}

public class CreateTerm
{
    [Required(ErrorMessage="الزامی است")]
    [Display(Name = "نام ترم")]
    [MaxLength(50)]
    public string Name { get; set; }
}

public class EditTerm : CreateTerm
{
    public int Id { get; set; }
}