using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAlumno.Models;

namespace WebAlumno.Controllers
{
    public class CursosController : Controller
    {
        CursosEntities db = new CursosEntities();

        // GET: Cursos
        public ActionResult Index()
        {

            return View(db.Curso);
        }

        public ActionResult Alta()
        {
            return View(new Curso());
            
        }

        [HttpPost]
        [ValidateAntiForgeryTokenAttribute]

        public ActionResult Alta(Curso model)
        {
            if (ModelState.IsValid)
            {
                db.Curso.Add(model);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View();

        }

        public ActionResult Borrar(int id)
        {
            var model = db.Curso.Find(id); // priero que lo encuentre el curso que quiero borrar

            try
            {
                db.Curso.Remove(model); // y aqui lo borra y lo vuelve a cargar
                db.SaveChanges();
            }
            
            catch (Exception ee)
            {
                Console.WriteLine(ee);

            }
           
            return RedirectToAction("Index");

        }

        public ActionResult Modificar(int id)
        {
            var curso = db.Curso.Find(id);


            return View(curso);
        }
        [HttpPost]

        public ActionResult Modificar(Curso model) // vuelco los datos en la base de datos
        {
            if (ModelState.IsValid)
            {
                var m = db.Curso.Find(model.id);
                m.Nombre = model.Nombre;
                m.inicio = model.inicio;
                m.fin = model.fin;

                db.SaveChanges();

                return RedirectToAction("Index");

            }

            return View(model);
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            db.Dispose();
        }
    }
}