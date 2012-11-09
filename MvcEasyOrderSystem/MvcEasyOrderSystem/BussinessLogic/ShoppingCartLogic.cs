﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MvcEasyOrderSystem.Models;
using MvcEasyOrderSystem.Models.Repositry;
using System.Web.Mvc;

namespace MvcEasyOrderSystem.BussinessLogic
{
    public class ShoppingCartLogic
    {
        const string userIdSessionKey = "UserId";
        public string ShoppingCartId { get; set; }
        private IGenericRepository<ShoppingCart> shoppingCartRepo;
        private IGenericRepository<Meal> mealRepo;

        private ShoppingCartLogic(IGenericRepository<ShoppingCart> inShoppingCartRepo,
            IGenericRepository<Meal> inMealRepo)
        {
            shoppingCartRepo = inShoppingCartRepo;
            mealRepo = inMealRepo;
        }

        private ShoppingCartLogic()
            : this(new GenericRepository<ShoppingCart>(), new GenericRepository<Meal>())
        {
        }


        public string GetUserId(HttpContextBase context)
        {
            if (context.Session[userIdSessionKey] == null)
            {
                if (string.IsNullOrEmpty(context.User.Identity.Name))
                {
                    context.Session[userIdSessionKey] = Guid.NewGuid().ToString();
                }
                else
                {
                    context.Session[userIdSessionKey] = context.User.Identity.Name.ToString();
                }
            }
            return context.Session[userIdSessionKey].ToString();

        }

        public static ShoppingCartLogic GetShoppingCart(HttpContextBase inContext)
        {
            ShoppingCartLogic cart = new ShoppingCartLogic();
            cart.ShoppingCartId = cart.GetUserId(inContext);
            return cart;
        }

        public IEnumerable<ShoppingCart> GetShoppingCartItems()
        {
            var result = shoppingCartRepo.GetWithFilterAndOrder(x => x.UserId == ShoppingCartId);
            return result;
        }

        public void AddToCart(int mealId)
        {
            ShoppingCart result = shoppingCartRepo.GetSingleEntity(
                x => x.UserId == ShoppingCartId && x.MealId == mealId);

            if (result == null)
            {
                var mealDetail = mealRepo.GetSingleEntity(x => x.MealId == mealId);
                shoppingCartRepo.Insert(new ShoppingCart
                {
                    MealId = mealDetail.MealId,
                    MealName = mealDetail.MealName,
                    Quantity = 1,
                    UnitPrice = mealDetail.Price,
                    UserId = ShoppingCartId,
                });

            }
            else
            {
                result.Quantity = result.Quantity + 1;
                shoppingCartRepo.Update(result);
            }

            shoppingCartRepo.SaveChanges();
        }

    }
}