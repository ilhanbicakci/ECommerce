using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using Core.Abstracts;
using Core.Concretes.Entities;
using Data;
using Data.Contexts;

namespace UI.ControlPanel.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IUnitOfWork uow = new UnitOfWork();
        private readonly IMapper mapper;

        public ProductsController()
        {
            mapper = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<Product, Product>()));
        }



        // GET: Products
        public ActionResult Index()
        {
            var products = uow.ProductRepo.ReadMany(null, new string[] { "Category" });
            return View(products );
        }

        // GET: Products/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = uow.ProductRepo.ReadOne(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: Products/Create
        public ActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(uow.CategoryRepo.ReadMany(x => x.Active && !x.Deleted), "Id", "Name");
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Price,Description,CategoryId,ProductModelId,Discounted,DiscountRatio,TaxRatio,Active,Deleted,CreateDate")] Product product)
        {
            if (ModelState.IsValid)
            {
                uow.ProductRepo.CreateOne(product);
                uow.Commit();
                return RedirectToAction("Index");
            }

            ViewBag.CategoryId = new SelectList(uow.CategoryRepo.ReadMany(x => x.Active && !x.Deleted), "Id", "Name", product.CategoryId);

            return View(product);
        }

        // GET: Products/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = uow.ProductRepo.ReadOne(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryId = new SelectList(uow.CategoryRepo.ReadMany(x => x.Active && !x.Deleted), "Id", "Name", product.CategoryId);
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Price,Description,CategoryId,Discounted,DiscountRatio,TaxRatio,Active,Deleted,CreateDate")] Product product)
        {
            if (ModelState.IsValid)
            {
                var old = uow.ProductRepo.ReadOne(product.Id);
                
                old.Name = product.Name;
                old.Price = product.Price;
                old.Description = product.Description;
                old.CategoryId = product.CategoryId;
                old.Discounted = product.Discounted;
                old.DiscountRatio = product.DiscountRatio;
                old.TaxRatio = product.TaxRatio;
                old.Active = product.Active;
                old.Deleted = product.Deleted;
                uow.ProductRepo.UpdateOne(old);

                uow.Commit();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryId = new SelectList(uow.CategoryRepo.ReadMany(x => x.Active && !x.Deleted), "Id", "Name", product.CategoryId);
            return View(product);
        }

        // GET: Products/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = uow.ProductRepo.ReadOne(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Product product = uow.ProductRepo.ReadOne(id);
            uow.ProductRepo.DeleteOne(product);
            uow.Commit();
            return RedirectToAction("Index");
        }
    }
}
