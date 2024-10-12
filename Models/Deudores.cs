using System.ComponentModel.DataAnnotations;

namespace FrannielAriasR_Ap1_P1.Models
{
    public class Deudores
    {
        [Key]
        public int DeudorId { get; set; }

        [Required]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "En este campo solo se permiten letras. ")]
        public string? Nombres { get; set; }
    }
}
