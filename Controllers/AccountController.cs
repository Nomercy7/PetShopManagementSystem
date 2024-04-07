using Store.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Store.Controllers
{
    public class AccountController : Controller
    {
        public static bool isLoggedIn = false;
        public static bool isAdmin = false;
        public static bool isUser = false;

        PetStoreEntities4 db= new PetStoreEntities4();
        // GET: Account
        public ActionResult Index()
        {
            if(isLoggedIn==false || isAdmin==false)
                return HttpNotFound();

            return View();
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(tb_user ur)
        {
            if(ModelState.IsValid)
            {
                if(db.tb_user.Any(x => x.Email == ur.Email))
                {
                    ViewBag.Message = "Email already Registered";
                }
                else
                {
                    db.tb_user.Add(ur);
                    db.SaveChanges();
                    Response.Write("<script>alert('Registration Successful')</script>");
                }
            }
            return View();
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(MyLogin l)
        {
            /*var query = db.tb_admin.SingleOrDefault(n => n.email == l.Email && n.password == l.Password);
            var query1 = db.tb_user.SingleOrDefault(n => n.Email == l.Email && n.password == l.Password);
            //Session["id"] = Convert.ToInt32(query.id);

            if(query == null && query1!=null)
            {
                isLoggedIn = true;
                isUser = true;
                //Response.Write("<script>alert('Login Successful')</script>");
                Response.Redirect("~/tb_pet/UserDisplay"); 
            }
            else if(query != null && query1 == null)
            {
                isLoggedIn = true;
                isAdmin = true;
                Response.Redirect("~/tb_pet/Index");
            }
            else
            {
                Response.Write("<script>alert('Invalid Credentials')</script>");
                //Response.Redirect("~/tb_pet/UserDisplay");

            }
            return View();*/
            var user = db.tb_user.SingleOrDefault(m => m.Email == l.Email && m.password == l.Password);
            var admin = db.tb_admin.SingleOrDefault(m => m.email == l.Email && m.password == l.Password);
            if(user !=null)
            {
                Session["isLoggedIn"] = true;
                Session["isUser"] = true;
                Session["UserName"] = user.UserName;

                return RedirectToAction("UserDisplay", "tb_pet");
            }
            else if(admin != null)
            {
                Session["isLoggedIn"] = true;
                Session["isAdmin"] = true;
                Session["UserName"] = admin.admin_name;

                return RedirectToAction("Index", "tb_pet");

            }
            else
            {
                ViewBag.ErrorMessage = "Invalid Credentials";
                return View();
            }
        }

       

        

        public ActionResult Logout()
        {
            isLoggedIn = false;
            isUser=false;
            isAdmin=false;
            return RedirectToAction("Index","Home");
        }


    }

    
}