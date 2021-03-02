using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyEcommShop.Core.Models;
using MyEcommShop.DataAccess.InMemory;


namespace MyEcommShop.WebUI.Controllers
{
    public class ProductCatagoryManagerController : Controller
    {
        ProductCatagoryRepository MyProdCatagoryRep; //old Product Catagory Repository
        // Now replace with InMeemoryrepository with any Object Type parameter
        //InMemoryRepository<ProductCatagory> MyProdCatagoryRep;
        public ProductCatagoryManagerController()
        {
            MyProdCatagoryRep = new ProductCatagoryRepository();
           //MyProdCatagoryRep = new InMemoryRepository<ProductCatagory>();
        }
        // GET: ProductManager
        public ActionResult Index()
        {
            //List<ProductCatagory> MyProductCatagory = MyProdCatagoryRep.Collection().ToList();
            List<ProductCatagory> MyProductCatagory = MyProdCatagoryRep.Collection().ToList();
            return View(MyProductCatagory);
        }
        public ActionResult Create()
        {
            ProductCatagory  MyProductCatagory = new ProductCatagory();
            return View(MyProductCatagory);
        }
        [HttpPost]
        public ActionResult Create(ProductCatagory  paramProductCatagory)
        {
            if (! ModelState.IsValid )
            {
                return View(paramProductCatagory);
            }
            else
            {
                MyProdCatagoryRep.Insert(paramProductCatagory);
                MyProdCatagoryRep.Commit();
                return RedirectToAction("Index");
            }
            
        }
        public ActionResult Edit(string Id)
        {
            ProductCatagory MyProductCatagory = MyProdCatagoryRep.Find(Id);
            if (MyProductCatagory == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(MyProductCatagory);
            }
        }
        [HttpPost]
        public ActionResult Edit(ProductCatagory  MyProdCatagory,string Id)
        {
            ProductCatagory  productCatagToEdit = MyProdCatagoryRep.Find(Id);
            if (productCatagToEdit == null)
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
                    productCatagToEdit.ID = MyProdCatagory.ID;
                    productCatagToEdit.Catagory = MyProdCatagory.Catagory;
                    MyProdCatagoryRep.Commit();
                    return RedirectToAction("Index");
                }
            }
        }

        public ActionResult Delete(string Id)
        {
            ProductCatagory MyProdCatagToDelete = MyProdCatagoryRep.Find(Id);
            if(MyProdCatagToDelete == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(MyProdCatagToDelete) ;
            }
            
        }
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult ConfirmDelete(string Id)
        {
            ProductCatagory MyProdCatagToDelete = MyProdCatagoryRep.Find(Id);
            if (MyProdCatagToDelete == null)
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
                    MyProdCatagoryRep.Delete(Id);
                    MyProdCatagoryRep.Commit();
                    return RedirectToAction("Index");
                }
            }

        }
    }
}