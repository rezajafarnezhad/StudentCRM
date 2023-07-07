using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace StudentCRM.web.Common;

public class JsonResultOperation
{
    public bool IsSuccessful { get; }
    public string Message { get; }
    public object Data { get; set; }
    public JsonResultOperation(bool isSuccessful, string message = "خطایی به وجود آمد")
    {
        IsSuccessful = isSuccessful;
        Message = message;
    }
}

public static class s
{
    public static List<string> GetModelStateErrors(this ModelStateDictionary modelstate)
    {
        return modelstate.Keys.SelectMany(c => modelstate[c].Errors).Select(b => b.ErrorMessage).ToList();
    }

    public static string GetEnumDisplayName(this Enum enumValue)
    {
        if (enumValue is null)
            return "";

        return enumValue.GetType()
            .GetMember(enumValue.ToString())
            .First()
            .GetCustomAttribute<DisplayAttribute>()
            ?.GetName();
    }
}

