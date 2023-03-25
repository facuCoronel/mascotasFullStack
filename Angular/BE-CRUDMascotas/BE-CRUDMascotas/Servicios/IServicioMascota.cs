using BE_CRUDMascotas.Models;

namespace BE_CRUDMascotas.Servicios
{
    public interface IServicioMascota
    {
        Task<List<Mascota>> GetMascotas();
        Task<Mascota> GetMascotaId(int id);
        Task<int> DeleteMascotaById(int id);
        Task<int> PostMascota(Mascota mascota);
        Task<int> PutMascota(Mascota mascota);
    }
}
