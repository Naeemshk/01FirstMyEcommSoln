using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyEcommShop.Core.Models;
using MyEcommShop.DataAccess.InMemory;
using MyEcommShop.Core.ViewModels;


namespace MyEcommShop.WebUI.Controllers
{
    public class ProductManagerController : Controller
    {
        ProductRepository MyProdRep;
        ProductCatagoryRepository ProdCatagRepositry;
        public ProductManagerController()
        {
            MyProdRep = new ProductRepository();
            ProdCatagRepositry = new ProductCatagoryRepository();
        }
        // GET: ProductManager
        public ActionResult Index()
        {
            List<Product> MyProduct = MyProdRep.Collection().ToList();
            return View(MyProduct);
        }
        public ActionResult Create()
        {
            // Before we are passing  only Product as shown below
            //=============================================================
            //Product MyProduct = new Product();
            //return View(MyProduct );
            //=============================================================
            // but now we make a view model whcih contains one Product data
            // and collection of Product Catagories table data
            // and we are now passing this view model to Create Class
            ProductandCatagoryViewModel MyViewModel = new ProductandCatagoryViewModel();
            MyViewModel.Product = new Product(); // we are passing one record of Product
            MyViewModel.ProductCatagories = ProdCatagRepositry.Collection(); // we are passing collection of Product Catagory to view
            return View(MyViewModel);
        }
        [HttpPost]
        public ActionResult Create(ProductandCatagoryViewModel  paramProduct)
        {
            if (! ModelState.IsValid )
            {
                return View(paramProduct);
            }
            else
            {
                MyProdRep.Insert(paramProduct.Product);
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
                // Before this is reurn view for Product only
                // return View(MyProduct);

                // Now are are sending a single Product and Collection of Product Catagory as below
                ProductandCatagoryViewModel MyProdCatgViewModel = new ProductandCatagoryViewModel();
                MyProdCatgViewModel.Product = MyProduct;
                MyProdCatgViewModel.ProductCatagories = ProdCatagRepositry.Collection();
                return View(MyProdCatgViewModel);
                
            }
        }
        [HttpPost]
        public ActionResult Edit(ProductandCatagoryViewModel MyProd,string ID)
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
                    productToEdit.ID = MyProd.Product.ID;
                    productToEdit.Name = MyProd.Product.Name;
                    productToEdit.Description = MyProd.Product.Description;
                    productToEdit.Price = MyProd.Product.Price;
                    productToEdit.Catagory = MyProd.Product.Catagory;
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