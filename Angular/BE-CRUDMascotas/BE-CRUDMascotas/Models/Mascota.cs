namespace BE_CRUDMascotas.Models
{
    public class Mascota
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public string color { get; set; }
        public int edad { get; set; }
        public int peso { get; set; }
        public string raza { get; set; }

            /*id int,
            raza varchar(50),
            color varchar(50),
            edad int,
            peso int,
            nombre varchar(50)*/


    }
}
