using ParcialWebApi.Interfaces;

namespace ParcialWebApi.Services
{
    public class FechaService : IFechaService
    {
        public DateTime ObtenerFechaActual()
        {
            return DateTime.Now;
        }
    }
}
