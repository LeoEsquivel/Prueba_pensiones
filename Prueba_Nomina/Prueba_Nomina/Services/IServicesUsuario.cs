using System.Security.Claims;

namespace Prueba_Nomina.Services
{
    public interface IServicesUsuario
    {
        string ObtenerUsuarioId();
    }

    public class ServicesUsuarios : IServicesUsuario
    {
        private HttpContext httpContext;

        public ServicesUsuarios(IHttpContextAccessor httpContextAccessor) {
            httpContext = httpContextAccessor.HttpContext;
        }

        public string ObtenerUsuarioId()
        {
            if (httpContext.User.Identity.IsAuthenticated)
            {
                var idClaim = httpContext.User.Claims.
                    Where(x => x.Type == ClaimTypes.NameIdentifier).FirstOrDefault();

                return idClaim.Value;
            }
            else {
                throw new Exception("El usuario no esta autenticado");
            }
        }
    }

}
