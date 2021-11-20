using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProgramacionVisual_TP6.Models;


namespace ProgramacionVisual_TP6.Controllers
{
    public class LibroController : Controller
    {
        // GET: Libro
        public ActionResult Index()
        {
            try
            {
                using (var db = new BibliotecaEntities())
                {
                    //Envio la Lista a la vista para que la muestre
                    return View(db.Libro.ToList());
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public ActionResult Agregar()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Agregar(Libro l)
        
        { //Verifica el dato qe venga bien del lado servidor
            if (!ModelState.IsValid)
                return View();
            try
            {
                //para que abra y cierre la coneccion
                using (var db = new BibliotecaEntities())
                {
                    //a.FechaIncripcion = DateTime.Now;
                    //a.Sexo = a.Sexo.ToUpper();
                    db.Libro.Add(l);
                    db.SaveChanges();
                    return RedirectToAction("index");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Error al agregar el Libro " + ex.Message);
                return View();
            }
        }

        public ActionResult Editar(int Idlibro)
        
        { //Verifica el dato qe venga bien del lado servidor
            if (!ModelState.IsValid)
        
                return View();
            try
            {
                //para que abra y cierre la coneccion
                using (var db = new BibliotecaEntities())
                {
                    //where lo uso en cualquier caso
                    // Alumnos al = db.Alumnos.Where(a => a.Id == id).FirstOrDefault();
                    //uso el find si solo tengo una clave primaria. no me sirve con clave compuesta
                    Libro lib = db.Libro.Find(Idlibro);
                    return View(lib);
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Error al agregar el Libro " + ex.Message);
                return View();
            }
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(Libro l)
        {
            try
            {
                using (var db = new BibliotecaEntities())
                {
                    Libro lib = db.Libro.Find(l.Idlibro);
                    lib.Titulo = l.Titulo;
                    lib.Edicion = l.Edicion;
                    lib.Autor = l.Autor;
                    lib.ISBN = l.ISBN;
                    lib.Paginas = l.Paginas;
                    lib.Editorial = l.Editorial;
                    lib.Ciudadypais = l.Ciudadypais;
                    lib.Fechadeedicion = l.Fechadeedicion;
                    db.SaveChanges();
        
                    return RedirectToAction("index");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public ActionResult Detalles(int Idlibro)
        {
            using (var db = new BibliotecaEntities())
            {
                Libro lib = db.Libro.Find(Idlibro);
                return View(lib);
            }
        }

        public ActionResult Eliminar(int Idlibro)
        {
            using (var db = new BibliotecaEntities())
            {
                Libro lib = db.Libro.Find(Idlibro);
                db.Libro.Remove(lib);
                db.SaveChanges();
                return RedirectToAction("index");
            }
        }
    }
}