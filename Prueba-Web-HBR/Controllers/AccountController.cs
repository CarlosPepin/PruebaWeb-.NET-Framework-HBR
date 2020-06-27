using Prueba_Web_HBR.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Prueba_Web_HBR.Controllers
{
    public class AccountController : Controller
    {
        private readonly dbGestorProductosEntities db = new dbGestorProductosEntities();

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult RegisterUser(tblUsuario newUser)
        {
            if (ModelState.IsValid)
            {
                db.tblUsuarios.Add(newUser);
                db.SaveChanges();
                ViewBag.Message = "Usuario Registrado";
                return RedirectToAction("~/Home/Index");
            }
            return View(newUser);
        }
    }
}