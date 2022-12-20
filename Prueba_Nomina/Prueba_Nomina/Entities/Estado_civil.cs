using System.ComponentModel.DataAnnotations;

namespace Prueba_Nomina.Entities
{
    public class Estado_civil
    {
        public int Id { get; set; }

        [StringLength(30)]
        [Required]
        public string Estado { get; set; }
    }
}
