using System.ComponentModel.DataAnnotations;

namespace FrannielAriasR_Ap1_P1.Models;

public class Prestamo
{
    [Key]
    public int PrestamoId { get; set; }

    [Required(ErrorMessage = "Este campo es obligatorio.")]
    [RegularExpression(@"^[A-Za-z\s]+$", ErrorMessage = "Solo se permiten letras en este campo.")]
    public string? Deudor { get; set; }

    [Required(ErrorMessage = "Este campo es obligatorio")]
    [RegularExpression(@"^[A-Za-z\s]+$", ErrorMessage = "Solo se permiten letras en este campo.")]
    public string? Concepto { get; set; }

    [Required(ErrorMessage = "Este campo es obligatorio.")]
    [Range(minimum: 0.1, maximum: 9999999999999, ErrorMessage = "No se permiten valores menores a 0")]
    public decimal Monto { get; set; }
}
