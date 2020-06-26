using Prueba_Web_HBR.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Prueba_Web_HBR.Controllers
{
    public class CategoryController : Controller
    {
        private readonly dbGestorProductosEntities db = new dbGestorProductosEntities();

        public ActionResult CategoryList()
        {
            var category = db.tblCategorias.ToList();
            return View(category);
        }

        public ActionResult CategoryDetail(int id)
        {
            var employee = db.tblCategorias.SingleOrDefault(e => e.idCategoria == id);
            return View(employee);
        }

        [HttpGet]
        public ActionResult CategoryCreate() { return View(); }

        [HttpPost]
        public ActionResult CategoryCreate(tblCategoria newCategory)
        {
            if (ModelState.IsValid)
            {
                db.tblCategorias.Add(newCategory);
                db.SaveChanges();
                return RedirectToAction("CategoryList");
            }
            return View(newCategory);
        }

        [HttpGet]
        public ActionResult CategoryEdit(int id)
        {
            var category = db.tblCategorias.SingleOrDefault(e => e.idCategoria == id);
            return View(category);
        }

        [HttpPost]
        public ActionResult CategoryEdit(tblCategoria editatedCategory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(editatedCategory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("CategoryList");
            }

            return View(editatedCategory);
        }

        [HttpGet]
        public ActionResult CategoryDeleteConfirmed(int id)
        {
            var category = db.tblCategorias.SingleOrDefault(x => x.idCategoria == id);
            db.tblCategorias.Remove(category);
            db.SaveChanges();
            return RedirectToAction("CategoryList");
        }


    }
}