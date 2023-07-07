using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;

namespace StudentCRM.web.Pages
{
    public class PageBase : PageModel
    {
        public JsonResult Json(object input)
        {
            return new(input);
        }
    }
}
