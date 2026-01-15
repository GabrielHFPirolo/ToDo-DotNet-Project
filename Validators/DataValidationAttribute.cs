using System.ComponentModel.DataAnnotations;

namespace dotnet_CRUD.Validators;

public class DataValidationAttribute : ValidationAttribute
{
    public DataValidationAttribute()
    {
        ErrorMessage = "O campo {0} não pode ser uma data anterior à atual";
    }

    public override bool IsValid(object? value)
{
    if (value is null)
        return true;

    if (value is not DateOnly date)
        return false;

    return date >= DateOnly.FromDateTime(DateTime.Now);
}

}