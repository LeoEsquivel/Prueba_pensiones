using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Prueba_Nomina.Entities;
using Prueba_Nomina.Services;
using System.IO.Pipelines;
using System.Text;

namespace Prueba_Nomina.Controllers
{
    [Route("api/pensionado")]
    public class PensionadoController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IServicesUsuario servicesUsuario;

        public PensionadoController(ApplicationDbContext context, IServicesUsuario servicesUsuario)
        {
            this.context = context;
            this.servicesUsuario = servicesUsuario;
        }

        [HttpPost]
        public async Task<ActionResult<Pensionado>> Post([FromBody] Pensionado pensionado)
        {
            ReadResult requestBodyInBytes = await Request.BodyReader.ReadAsync();
            Request.BodyReader.AdvanceTo(requestBodyInBytes.Buffer.Start, requestBodyInBytes.Buffer.End);
            string body = Encoding.UTF8.GetString(requestBodyInBytes.Buffer.FirstSpan);
            Console.WriteLine(body);

            //var usuarioId = servicesUsuario.ObtenerUsuarioId();
            var pensionadoBD = new Pensionado();

            pensionadoBD.No_activo = pensionado.No_activo;
            pensionadoBD.Cobro_indebido = pensionado.Cobro_indebido;
            pensionadoBD.Clave_pension = pensionado.Clave_pension;
            pensionadoBD.No_afiliado = pensionado.No_afiliado;
            pensionadoBD.No_pension = pensionado.No_pension;
            pensionadoBD.Sexo = pensionado.Sexo;
            pensionadoBD.ApellidoP = pensionado.ApellidoP;
            pensionadoBD.ApellidoM = pensionado.ApellidoM;
            pensionadoBD.Nombre = pensionado.Nombre;
            pensionadoBD.Fecha_nacimiento = pensionado.Fecha_nacimiento;
            pensionadoBD.RFC = pensionado.RFC;
            pensionadoBD.CURP = pensionado.CURP;
            pensionadoBD.Estado_civilId = pensionado.Estado_civilId;
            pensionadoBD.Tipo_PensionId = pensionado.Tipo_PensionId;
            pensionadoBD.Email = pensionado.Email;
            
            context.Add(pensionadoBD);
            await context.SaveChangesAsync();
            return pensionado;
        }

        [HttpGet("estados_civiles")]
        public async Task<List<Estado_civil>> GetEstadosCiviles() { 
            return await context.Estados_Civiles.ToListAsync();
        }

        [HttpGet("tipo_pensiones")]
        public async Task<List<Tipo_Pension>> GetTipo_Pensiones()
        {
            return await context.Tipo_Pensiones.ToListAsync();
        }


    }
}
