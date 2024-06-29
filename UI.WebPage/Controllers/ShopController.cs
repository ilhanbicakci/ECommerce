using Business.Services;
using Core.Abstracts.IServices;
using Core.Concretes.DTOs;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Utilities.Models;

namespace UI.WebPage.Controllers
{
    public class ShopController : Controller
    {
        private readonly IShopService service;

        public ShopController()
        {
            service = new ShopService();
        }


        // GET: Shop
        public ActionResult Index(int page = 1)
        {
            return View(new GenericPagination<ProductListItemDTO>(service.GetProducts(x =>
            x.Active && !x.Deleted &&
            x.Category.Active && !x.Category.Deleted), page, 9));
        }

        
        public ActionResult Cart()
        {
            if (User.Identity.IsAuthenticated)
            {
                return Json(service.GetCart(User.Identity.GetUserId()),
                    JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { message = "Unauthenticated Request" },
                    JsonRequestBehavior.AllowGet);
            }
        }


        [HttpPost]
        public ActionResult AddToCart(int pid)
        {
            if (User.Identity.IsAuthenticated)
            {
                return Json(service.AddToCart(pid, User.Identity.GetUserId(), 1));
            }
            else
            {
                return Json(new { message = "Unauthenticated Request" });
            }
        }
    }
}