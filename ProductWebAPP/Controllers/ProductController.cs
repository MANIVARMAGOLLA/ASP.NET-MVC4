using ProductBusinessLayer;
using ProductDataTransfer;
using ProductWebAPP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProductWebAPP.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        ProdBL BLObj;

        public ProductController()
        {
            BLObj = new ProdBL();
        }
        public ActionResult ViewAllProduct()
        {
            try
            {
                List<ProdDTO> lstOfProduct = BLObj.GetAllProduct();
                List<ProductCustomerView> lsofFinalProduct = new List<ProductCustomerView>();
                foreach (var product in lstOfProduct)
                {
                    lsofFinalProduct.Add(new ProductCustomerView()
                    {
                        ProductName = product.ProductName,
                        ProductColor = product.ProductColor,
                        ProductListPrice = product.ProductListPrice
                    });
                }

                return View(lsofFinalProduct);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}