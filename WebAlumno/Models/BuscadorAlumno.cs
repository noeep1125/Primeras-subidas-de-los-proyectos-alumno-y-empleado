using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAlumno.Models
{
    public class BuscadorAlumno
    {

        CursosEntities db = new CursosEntities();

        // ESTO ES LINKCUBE, LAS DOS FUNCIONES SIGUIENTES
        public List<Alumnos> GetPorApellidos(string apellidos)
        { // o es cada alumno
            var datos = from o in db.Alumnos // lo llamo como quiera, es un objeto, lo esta creando en este momento, por cada elemento que haya en la tabla alumnos lo llamo "o"
                where o.apellidos == apellidos // si quiero enlazar mas cosas ponemos &&, ||
                select o;   // si la condicion del where se cumple, vuelca los datos en la variale "datos" 

            return datos.ToList();


        }

        public List<Alumnos> GetPorApellidosLambda(string apellidos) // EXPRESION LAMBDA:  ESTA FUNCION ES LA MISMA QUE LA DE ARRIBA
        {
            var datos = db.Alumnos.Where(o => o.apellidos == apellidos); 

            return datos.ToList();

        }
    }
}

// el Yqueryllable ... mejor poner lo que esta puesto, "var" que nos acordaremos mejor