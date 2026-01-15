using System.ComponentModel.DataAnnotations;
using dotnet_CRUD.Validators;

namespace dotnet_CRUD.Models;

public class Todo
{
    public int Id { get; set; }
    [Display(Name = "Título")]
    [Required(ErrorMessage = "Campo {0} é Obrigatório, preencha os dados")]
    [StringLength(100, MinimumLength = 4, 
    ErrorMessage ="O campo {0} deve conter de {2} a {1} caractéres")]
    public string Title { get; set; } = string.Empty;
    
    public DateTime CreatedAt { get; set; }
    [Display(Name = "Data Final")]
    [Required(ErrorMessage = "Campo {0} é obrigatório")]
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
    [DataValidation]
    public DateOnly DeadLine { get; set; }
    public DateOnly? FinishedAt { get; set; }

    public void Finish()
    {
        FinishedAt = DateOnly.FromDateTime(DateTime.Now);
    }
}
