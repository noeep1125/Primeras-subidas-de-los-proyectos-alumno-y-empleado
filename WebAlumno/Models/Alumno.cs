using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebAlumno.Models
{
    public partial class Alumnos

    {
        public List<int> idCursos { get; set; }

        [DisplayName("Dni ")]
        [RegularExpression("^[0-9]{8}[A-Za-z]{1}$", ErrorMessage = "El Dni es Incorrecto")]
        public string dni { get; set; }
        [DisplayName("Nombre ")]
        public string nombre { get; set; }
        [DisplayName("Apellidos ")]
        public string apellidos { get; set; }
        [DisplayName("Fecha de Naciemiento ")]
        public Nullable<System.DateTime> fechaNacimiento { get; set; }
        [DisplayName("Nacionalidad ")]
        public int idNacionalidad { get; set; }
    
    }
}