﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FrannielAriasR_Ap1_P1.Models
{
    public class CobrosDetalle
    {
        [Key]
        public int DetalleId { get; set; }

        public int CobroId { get; set; }

        public int PrestamoId { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio. ")]
        [Range(minimum: 0.1, maximum: 9999999999, ErrorMessage = "Ingrese un cantidad válida.")]
        public decimal ValorCobrado { get; set; }

        [ForeignKey("PrestamoId")]
        public ICollection<Prestamos> Prestamos { get; set; } = new List<Prestamos>();

    }
}