using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;

namespace FrannielAriasR_Ap1_P1.Models
{
    public class Cobros
    {
        [Key]
        public int CobroId { get; set; }

        [Required]
        public DateTime Fecha { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "Este campo es obligatorio. ")]
        [Range(minimum: 0.1, maximum: 9999999999, ErrorMessage = "Ingrese un cantidad válida.")]
        public decimal Monto { get; set; }

        [ForeignKey("Deudores")]
        public int DeudorId { get; set; }
        public Deudores? Deudores { get; set; }

        [ForeignKey("CobroId")]
        public ICollection<CobrosDetalle> CobroDetalle { get; set; } = new List<CobrosDetalle>();  
    }
}
