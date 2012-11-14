﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcEasyOrderSystem.Models;
using MvcEasyOrderSystem.Models.Repositry;
using MvcEasyOrderSystem.BussinessLogic;

namespace MvcEasyOrderSystem.Controllers
{

    public class ShoppingCartController : Controller
    {
        private IGenericRepository<ShoppingCart> shoppingCartRepo;
        private ShoppingCartLogic shoppingCartLogic;

        public ShoppingCartController(IGenericRepository<ShoppingCart> inShoppingCartRepo)
        {
            shoppingCartRepo = inShoppingCartRepo;
        }

        public ShoppingCartController()
            :this(new GenericRepository<ShoppingCart>())
        {
        }


        public ActionResult AddToCart(int mealId)
        {
            shoppingCartLogic = ShoppingCartLogic.GetShoppingCart(this.HttpContext);

            shoppingCartLogic.AddToCart(mealId);
            shoppingCartLogic.SaveChanges();

            return RedirectToAction("Index");
        }

        //
        // GET: /ShoppingCart/


        public ActionResult Index()
        {
            shoppingCartLogic = ShoppingCartLogic.GetShoppingCart(this.HttpContext);

            var viewModel = new ViewModels.ShoppingCartViewModel ();

            viewModel.CartItems = shoppingCartLogic.GetShoppingCartItems().ToList();
               viewModel.TotalPrice = shoppingCartLogic.GetShoppingCartTotalPrice(viewModel.CartItems);
            
            //TODO: bug on when shopping cart is empty
            return View(viewModel);
        }

        //
        // GET: /ShoppingCart/Details/5

        public ActionResult Details(int shoppingCartId = 0)
        {
            ShoppingCart shoppingcart = shoppingCartRepo.GetSingleEntity
                (x => x.ShoppingCartId == shoppingCartId);
            if (shoppingcart == null)
            {
                return HttpNotFound();
            }
            return View(shoppingcart);
        }

        public ActionResult EmptyShoppingCart(string userId)
        {
            //TODO: Make it ajax. All shopping cart can be wrap up into a partial view
            shoppingCartLogic = ShoppingCartLogic.GetShoppingCart(this.HttpContext);

            shoppingCartLogic.EmptyCart();
            return RedirectToAction("Index");
        }

        ////
        //// GET: /ShoppingCart/Create

        //public ActionResult Create()
        //{
        //    return View();
        //}

        ////
        //// POST: /ShoppingCart/Create

        //[HttpPost]
        //public ActionResult Create(ShoppingCart shoppingcart)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        shoppingCartRepo.ShoppingCarts.Add(shoppingcart);
        //        shoppingCartRepo.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    return View(shoppingcart);
        //}

        ////
        //// GET: /ShoppingCart/Edit/5

        //public ActionResult Edit(int id = 0)
        //{
        //    ShoppingCart shoppingcart = shoppingCartRepo.ShoppingCarts.Find(id);
        //    if (shoppingcart == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(shoppingcart);
        //}

        ////
        //// POST: /ShoppingCart/Edit/5

        //[HttpPost]
        //public ActionResult Edit(ShoppingCart shoppingcart)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        shoppingCartRepo.Entry(shoppingcart).State = EntityState.Modified;
        //        shoppingCartRepo.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View(shoppingcart);
        //}

        ////
        //// GET: /ShoppingCart/Delete/5
       
        public ActionResult Delete(int shoppingCartId = 0)
        {
            shoppingCartLogic = ShoppingCartLogic.GetShoppingCart(this.HttpContext);
            ShoppingCart shoppingcart = shoppingCartLogic.GetShoppingCartUsingShoppingCartId(shoppingCartId);

            if (shoppingcart == null)
            {
                return HttpNotFound();
            }
            return View(shoppingcart);
        }

        //
        // POST: /ShoppingCart/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int shoppingCartId)
        {
            shoppingCartLogic = ShoppingCartLogic.GetShoppingCart(this.HttpContext);

            shoppingCartLogic.RemoveFromCart(shoppingCartId);

            shoppingCartLogic.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            shoppingCartRepo.Dispose();
            base.Dispose(disposing);
        }
    }
}