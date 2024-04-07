using Store.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Store.Controllers
{
    public class tb_buyController : Controller
    {
        private PetStoreEntities4 db=new PetStoreEntities4();
        // GET: tb_buy
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult OrdersList() 
        {
            return View(db.tb_buy.ToList());
        }
    }
}