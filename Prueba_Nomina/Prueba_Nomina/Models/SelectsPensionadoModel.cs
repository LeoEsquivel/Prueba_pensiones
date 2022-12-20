using Microsoft.AspNetCore.Mvc.Rendering;

namespace Prueba_Nomina.Models
{
    public class SelectsPensionadoModel
    {
        public IEnumerable<SelectListItem> Estados_civiles { get; set; }    
        public int Estados_civilId { get; set; }

        public IEnumerable<SelectListItem> Tipo_pension { get; set; }
        public int Tipo_pensionId { get; set; }
    }
}
