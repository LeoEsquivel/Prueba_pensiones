using System.ComponentModel.DataAnnotations;

namespace Prueba_Nomina.Entities
{
    public class Movimientos
    {
        public int Id { get; set; }

        [MaxLength(50)]
        [Required]
        public string Movimiento { get; set; }
    }
}
