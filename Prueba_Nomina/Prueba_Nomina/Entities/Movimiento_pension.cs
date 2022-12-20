using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;

namespace Prueba_Nomina.Entities
{
    public class Movimiento_pension
    {
        public int Id { get; set; }

        [Required]
        public int PensionadoId { get; set; }
        public Pensionado pensionado { get; set; }

        [Required]
        public int MovimientosId { get; set; }
        public Movimientos movimientos { get; set; }

        [Required]
        public float Importe { get; set; }

        [Required]
        public DateTime Fecha_inicio { get; set; }

        [Required]
        public DateTime Fecha_final { get; set; }

        [Required]
        public bool Tipo { get; set; }  
    }
}
