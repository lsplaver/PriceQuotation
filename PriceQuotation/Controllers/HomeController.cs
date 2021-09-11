using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PriceQuotation.Models;

namespace PriceQuotation.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.DiscountAmount = 0;
            ViewBag.TotalPrice = 0;
            return View();
        }

        [HttpPost]
        public IActionResult Index(PriceQuotationModel model)
        {
            if (ModelState.IsValid)
            {
                ViewBag.DiscountAmount = model.CalculateDiscountAmountAndTotalPrice().GetValue(0); //.CalculateDiscountAmount();
                ViewBag.TotalPrice = model.CalculateDiscountAmountAndTotalPrice().GetValue(1); //.CalculateTotalPrice();
            }
            else
            {
                ViewBag.DiscountAmount = 0;
                ViewBag.TotalPrice = 0;
            }
            return View(model);
        }
    }
}
