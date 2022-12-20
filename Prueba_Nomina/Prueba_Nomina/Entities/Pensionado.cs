using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace Prueba_Nomina.Entities
{
    public class Pensionado
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo No. Activo es obligatorio")]
        public int No_activo { get; set; }

        public bool Cobro_indebido { get; set; }    

        [Required(ErrorMessage = "El campo es obligatorio")]
        public bool Status_pago { get; set; }

        [Required(ErrorMessage = "La clave de pensión es obligatoria")]
        public int Clave_pension { get; set; }

        [Required(ErrorMessage = "El No. afiliado es obligatorio")]
        public int No_afiliado { get; set; }

        [Required(ErrorMessage = "El No. pensión es obligatorio")]
        public int No_pension { get; set; }

        [Required]
        public bool Sexo { get; set; }

        [MaxLength(50)]
        [Required(ErrorMessage = "El apeliido es obligatorio")]
        public string ApellidoP { get; set; }

        [MaxLength(50)]
        [Required(ErrorMessage = "El apellido es obligatorio")]
        public string ApellidoM { get; set; }

        [MaxLength(50)]
        [Required(ErrorMessage = "El nombre es obligatorio")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "La fecha de nacimiento es obligatoria")]
        public DateTime Fecha_nacimiento { get; set; }

        [MaxLength(13), MinLength(13)]
        [Required(ErrorMessage = "El RFC es obligatorio")]
        public string RFC { get; set; }

        [MaxLength(18), MinLength(18)]
        [Required(ErrorMessage = "El Curp es obligatorio")]
        public string CURP { get; set; }

        [MaxLength(50)]
        public string Email { get; set; }

        public int Estado_civilId { get; set; } 
        public Estado_civil estado_Civil { get; set; }

        public int Tipo_PensionId { get; set; }
        public Tipo_Pension tipo_Pension { get; set; }

    }
}
