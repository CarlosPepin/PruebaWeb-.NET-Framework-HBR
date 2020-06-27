using Microsoft.Ajax.Utilities;
using Prueba_Web_HBR.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Prueba_Web_HBR.Controllers
{
    public class HomeController : Controller
    {
        private readonly dbGestorProductosEntities db = new dbGestorProductosEntities();

        public ActionResult Index()
        {
            return View();
        }

        #region Registro de Usuario
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(tblUsuario newUser)
        {
            if (ModelState.IsValid)
            {
                db.tblUsuarios.Add(newUser);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
        #endregion

        #region Login
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(tblUsuario _user)
        {
            var details = (from r in db.tblUsuarios
                           where r.Email == _user.Email && r.Contraseña == _user.Contraseña
                           select new
                           {
                               r.idUsuario,
                               r.NombreUsuario
                           }).ToList();

            if (details.FirstOrDefault() != null)
            {
                Session["idUsuario"] = details.FirstOrDefault().idUsuario;
                Session["NombreUsuario"] = details.FirstOrDefault().NombreUsuario;
                return RedirectToAction("Welcome", "Home");
            }
            return View(_user);
        }
        #endregion

        #region Editar Usuario
        [HttpGet]
        public ActionResult EditUser(int id)
        {
            var user = db.tblUsuarios.SingleOrDefault(e => e.idUsuario == id);
            return View(user);
        }
        
        [HttpPost]
        public ActionResult EditUser(tblUsuario editatedUser)
        {
            if (ModelState.IsValid)
            {
                db.Entry(editatedUser).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Welcome");
            }
            return View(editatedUser);
        }
        #endregion

        public ActionResult Welcome()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}