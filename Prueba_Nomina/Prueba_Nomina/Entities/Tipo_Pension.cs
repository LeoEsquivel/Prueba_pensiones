using System.ComponentModel.DataAnnotations;

namespace Prueba_Nomina.Entities
{
    public class Tipo_Pension
    {
        public int Id { get; set; }

        [MaxLength(50)]
        [Required]
        public string Tipo { get; set; }
    }
}
