using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyEcommShop.Core.Models;
using MyEcommShop.DataAccess.InMemory;


namespace MyEcommShop.WebUI.Controllers
{
    public class ProductManagerController : Controller
    {
        ProductRepository MyProdRep;
        public ProductManagerController()
        {
            MyProdRep = new ProductRepository();
        }
        // GET: ProductManager
        public ActionResult Index()
        {
            List<Product> MyProduct = MyProdRep.Collection().ToList();
            return View(MyProduct);
        }
        public ActionResult Create()
        {
            Product MyProduct = new Product();
            return View(MyProduct );
        }
        [HttpPost]
        public ActionResult Create(Product  paramProduct)
        {
            if (! ModelState.IsValid )
            {
                return View(paramProduct);
            }
            else
            {
                MyProdRep.Insert(paramProduct);
                MyProdRep.Commit();
                return RedirectToAction("Index");
            }
            
        }
        public ActionResult Edit(string ID)
        {
            Product MyProduct = MyProdRep.Find(ID);
            if (MyProduct == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(MyProduct);
            }
        }
        [HttpPost]
        public ActionResult Edit(Product MyProd,string ID)
        {
            Product productToEdit = MyProdRep.Find(ID);
            if (productToEdit == null)
            {
                return HttpNotFound();
            }
            else
            {
                if(!ModelState.IsValid )
                {
                    return HttpNotFound();
                }
                else
                {
                    productToEdit.ID = MyProd.ID;
                    productToEdit.Name = MyProd.Name;
                    productToEdit.Description = MyProd.Description;
                    productToEdit.Price = MyProd.Price;
                    productToEdit.Catagory = MyProd.Catagory;
                    MyProdRep.Commit();
                    return RedirectToAction("Index");
                }
            }
        }

        public ActionResult Delete(string ID)
        {
            Product MyProdToDelete = MyProdRep.Find(ID);
            if(MyProdToDelete == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(MyProdToDelete) ;
            }
            
        }
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult ConfirmDelete(string ID)
        {
            Product MyProdToDelete = MyProdRep.Find(ID);
            if (MyProdToDelete == null)
            {
                return HttpNotFound();
            }
            else
            {
                if (!ModelState.IsValid)
                {
                    return HttpNotFound();
                }
                else
                {
                    MyProdRep.Delete(ID);
                    MyProdRep.Commit();
                    return RedirectToAction("Index");
                }
            }

        }
    }
}