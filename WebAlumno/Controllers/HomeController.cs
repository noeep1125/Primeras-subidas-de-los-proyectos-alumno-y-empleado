using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Web;
using System.Web.Mvc;
using WebAlumno.Models;

namespace WebAlumno.Controllers
{
    public class HomeController : Controller
    {
        private CursosEntities db = new CursosEntities();
        // GET: Home
        public ActionResult Index()
        {

         
                return View(db.Alumnos.ToList());
                    // me devuelve toda la lista de la base de datos, se encarga de ello el entity framework
            
            // el using aqui lo que hace es borrar o cerrar las cosas de la memoria, lo lleva al recolector de basura
        }


        public ActionResult Alta()
        {
            ViewBag.idNacionalidad = new SelectList(db.Nacionalidades,"id","nombre"); // para seleccionar 1
            ViewBag.idCursos = new MultiSelectList(db.Curso, "id", "nombre"); // para seleccionar muchos
            return View(new Alumnos());
        }

        [HttpPost] // esto es un atributo, se aplica al metodo que va a continuacion, alta va a ir por post
        public ActionResult Alta(Alumnos model )
        {

            if (ModelState.IsValid) // si los 3 campos tienen algo puesto (nombre,apellidos y dni) entonces es OK // MODELSTATE es el estado en que se encuentra en este momento nuestro  model
            {

                using (var db = new CursosEntities())
                {
                    db.Alumnos.Add(model);

                    foreach (var idCurso in model.idCursos)
                    {
                        var c = db.Curso.Find(idCurso);
                        model.Curso.Add(c);

                    }

                    db.SaveChanges(); // guardado de cambios, confirmacion de los cambios
                    return RedirectToAction("Index");

                }
            }
                          
            return View(model);
        }


        public ActionResult Buscar()
        {
            var bus = Request.Form["busqueda"];
            var db = new CursosEntities();
            var al = db.Alumnos.Where(o => o.apellidos.Contains(bus));

            return View(al);
        }

    }
}

