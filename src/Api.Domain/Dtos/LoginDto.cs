using System.ComponentModel.DataAnnotations;

namespace Domain.Dtos
{
  public class LoginDto
  {
    [Required(ErrorMessage = "Email é campo obrigatorio")]
    [EmailAddress(ErrorMessage = "Email em formato invalido")]
    [StringLength(100, ErrorMessage = "Email deve ter no maximo {1} caracteres")]
    public string Email { get; set; }
  }
}
