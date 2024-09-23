using System.ComponentModel.DataAnnotations;

namespace FrannielAriasR_Ap1_P1.Models;

public class Registro
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string Name { get; set; }
}
