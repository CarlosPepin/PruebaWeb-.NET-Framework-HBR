using Prueba_Web_HBR.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Prueba_Web_HBR.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        private readonly dbGestorProductosEntities db = new dbGestorProductosEntities();

        public ActionResult ProductList(string searching)
        {
            var product = from s in db.tblProductoes select s;

            if (!string.IsNullOrEmpty(searching))
            {
                product = product.Where(p => p.NombreProducto.Contains(searching) || p.NombreProducto.Contains(null));
            }
            return View(product.ToList());
        }

        public ActionResult ProductDetail(int id)
        {
            var product = db.tblProductoes.SingleOrDefault(e => e.idProducto == id);
            return View(product);
        }

        [HttpGet]
        public ActionResult ProductCreate() { return View(); }

        [HttpPost]
        public ActionResult ProductCreate(tblProducto newProduct)
        {
            if (ModelState.IsValid)
            {
                db.tblProductoes.Add(newProduct);
                db.SaveChanges();
                return RedirectToAction("ProductList");
            }
            return View(newProduct);
        }

        [HttpGet]
        public ActionResult ProductEdit(int id)
        {
            var product = db.tblProductoes.SingleOrDefault(e => e.idProducto == id);
            return View(product);
        }

        [HttpPost]
        public ActionResult ProductEdit(tblProducto editatedProduct)
        {
            if (ModelState.IsValid)
            {
                db.Entry(editatedProduct).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("ProductList");
            }

            return View(editatedProduct);
        }

        [HttpGet]
        public ActionResult ProductDeleteConfirmed(int id)
        {
            var product = db.tblProductoes.SingleOrDefault(x => x.idProducto == id);
            db.tblProductoes.Remove(product);
            db.SaveChanges();
            return RedirectToAction("ProductList");
        }
    }
}