namespace Entidades
{
    public class Carrera
    {

        public int Id { get; set; }
        public string Codigo { get; set; }
        public string NombreCarrera { get; set; }
        public string AreaNegocio { get; set; }
        public bool Estado { get; set; }
    }

    public class CarreraAsignatura
    {
        public Carrera Carrera = new Carrera();
        public Asignatura Asignatura = new Asignatura();

    }
}

