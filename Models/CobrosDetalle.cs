using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FrannielAriasR_Ap1_P1.Models
{
    public class CobrosDetalle
    {
        [Key]
        public int DetalleId { get; set; }

        public int CobroId { get; set; }
        [ForeignKey("CobroId")]
        public Cobros? Cobros { get; set; }  // Enlace a Cobros

        public int PrestamoId { get; set; }
        [ForeignKey("PrestamoId")]
        public Prestamos? Prestamo { get; set; }  // Enlace a Prestamos (un solo Prestamo)

        [Required(ErrorMessage = "Este campo es obligatorio. ")]
        [Range(minimum: 0.1, maximum: 9999999999, ErrorMessage = "Ingrese un cantidad válida.")]
        public decimal ValorCobrado { get; set; }  // Campo validado para la cantidad cobrada
    }
}
