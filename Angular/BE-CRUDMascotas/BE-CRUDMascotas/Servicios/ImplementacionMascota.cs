using BE_CRUDMascotas.AccesoDatos.ConexionBd;
using BE_CRUDMascotas.Models;
using Dapper;

namespace BE_CRUDMascotas.Servicios
{
    public class ImplementacionMascota : IServicioMascota
    {
        ConexioBd _conn;

        public ImplementacionMascota(ConexioBd conn)
        {
            _conn = conn;
        }

        public async Task<int> DeleteMascotaById(int id)
        {
            string query = @"delete from Mascotas where id = @id";
            using(var bd = _conn.Conectar())
            {
                var result = (await bd.ExecuteAsync(query, new { id = id }));

                return result;
            }
        }

        public async Task<Mascota> GetMascotaId(int id)
        {
            string query = $"select * from mascotas where id = {id}";

            using (var bd = _conn.Conectar())
            {
                var result = (await bd.QueryFirstAsync<Mascota>(query));

                return result;
            }
        }

        public async Task<List<Mascota>> GetMascotas()
        {
            string query = "select * from mascotas";

            using (var bd = _conn.Conectar())
            {
                var result = (await bd.QueryAsync<Mascota>(query)).ToList<Mascota>();

                return result;
            }

        }

        public async Task<int> PostMascota(Mascota mascota)
        {
            string query = @"insert into Mascotas(nombre, raza, color, peso, edad) values (@nombre, @raza, @color,@peso,@edad)";


            using (var bd = _conn.Conectar())
            {
                var result = (await bd.ExecuteAsync(query, new
                {
                    nombre = mascota.nombre,
                    mascota.raza,
                    mascota.color,
                    mascota.peso,
                    mascota.edad
                }));

                return result;
            }
        }

        public async Task<int> PutMascota(Mascota mascota)
        {
            string query = "update mascotas set nombre = @nombre, raza = @raza, peso = @peso, edad = @edad, color = @color where id = @id";

            using(var conn = _conn.Conectar())
            {
                var result = await conn.ExecuteAsync(query, new
                {
                    id = mascota.id,
                    nombre = mascota.nombre,
                    raza = mascota.raza,
                    peso = mascota.peso,
                    edad = mascota.edad,
                    color = mascota.color
                }) ;

                return result;
            }
        }
    }
}
