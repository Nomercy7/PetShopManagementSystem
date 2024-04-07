using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Store.Models;
 


namespace Store.Controllers

{

    //[Authorize]

    public class tb_cartController : Controller

    {

        PetStoreEntities4 db = new PetStoreEntities4();

        // GET: MyCart


        public ActionResult CartView()

        {
            //var carts = new tb_cart();
            List<tb_cart> cart = Session["Cart"] as List<tb_cart>;
            if (cart == null)

            {

                cart = new List<tb_cart>();

                Session["Cart"] = cart;

            }

            return View(cart);

        }

        public ActionResult PaidView()

        {

            return View();

        }



        // GET: Products/AddToCart

        [HttpPost]

        public ActionResult AddToCart(int id, string pet_name, int price, int quantity = 1)

        {

            List<tb_cart> cart = Session["Cart"] as List<tb_cart> ?? new List<tb_cart>();

            tb_cart existingItem = cart.FirstOrDefault(item => item.id == id);

            if (existingItem != null)

            {

                existingItem.Quantity += quantity;

            }

            else

            {

                cart.Add(new tb_cart { id = id, price = price, pet_name = pet_name, Quantity = quantity });

            }

            Session["Cart"] = cart;

            return RedirectToAction("CartView");

        }

        public ActionResult RemoveFromCart(int id)

        {

            List<tb_cart> cart = Session["Cart"] as List<tb_cart>;

            if (cart != null)

            {

                cart.RemoveAll(item => item.id == id);

                Session["Cart"] = cart;

            }

            return RedirectToAction("CartView");

        }

        public int GetCurrentUserId()

        {
            
            return 9;

        }

        public ActionResult Checkout()

        {

            // Retrieve cart items from session

            List<tb_cart> cartItems = Session["Cart"] as List<tb_cart>;

            if (cartItems == null || cartItems.Count == 0)

            {

                // Redirect to an empty cart page or display a message

                return RedirectToAction("EmptyCart");

            }

            // Calculate total amount

            int price = (int)cartItems.Sum(item => (item.price * item.Quantity));

            // Create a new order

            var buy = new tb_buy

            {

                id = GetCurrentUserId(), // Replace with actual logic to get the current user ID

                price = price,

                buy_date = DateTime.Now,

                // Set the initial order status

            };

            // Save the order to the database
            
            db.tb_buy.Add(buy);

            db.SaveChanges();

            // Optionally, you can clear the cart session after creating the order

            Session["Cart"] = null;

            // Redirect to the order confirmation page with the order ID

            return RedirectToAction("PaidView", new { orderId = buy.id });

        }

        public ActionResult ClearCart()

        {

            //Session.Clear();

            Session.Remove("Cart");

            return Redirect("~/tb_pet/UserDisplay");

        }

    }

}

