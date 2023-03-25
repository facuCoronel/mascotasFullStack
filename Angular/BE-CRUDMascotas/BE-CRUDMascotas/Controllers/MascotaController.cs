using BE_CRUDMascotas.Models;
using BE_CRUDMascotas.Servicios;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BE_CRUDMascotas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MascotaController : ControllerBase
    {
        IServicioMascota _sm;

        public MascotaController(IServicioMascota sm)
        {
            _sm = sm;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _sm.GetMascotas();
            Thread.Sleep(2000);
            if (result != null)
            {
                return Ok(result);
            }
            else return BadRequest(result);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetId(int id)
        {
            Thread.Sleep(2000);
            try
            {
                var result = await _sm.GetMascotaId(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteById(int id)
        {
            try
            {
                var result = await _sm.DeleteMascotaById(id);

                return Ok(result);

            }catch (Exception ex)
            {
                return BadRequest(ex);
            }

        }
        [HttpPost]
        public async Task<IActionResult> PostMascota(Mascota mascota)
        {
            try
            {
                var result = await _sm.PostMascota(mascota);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }



        [HttpPut("{id}")]
        public async Task<IActionResult> PutMascota(int id, Mascota mascota)
        {
            try
            {
                var mascotaItem = await _sm.GetMascotaId(id);

                mascotaItem.nombre = mascota.nombre;
                mascotaItem.color = mascota.color;
                mascotaItem.id = mascota.id;
                mascotaItem.edad = mascota.edad;
                mascotaItem.peso = mascota.peso;
                mascotaItem.raza = mascota.raza;

                if(id != mascota.id)
                {
                    return BadRequest();
                }

                var result = await _sm.PutMascota(mascota);


                return Ok(result);
            }catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
