using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using CalculatorCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebCalculator.Models;

namespace WebCalculator.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(string calculatorInput)
        {

            Calculator calc = HttpContext.Session.Get<Calculator>("calc");

            if (calc == null)
            {
                calc = new Calculator();
            }

            EvaluationResult result = calc.Evaluate(calculatorInput);
            
            if (String.IsNullOrEmpty(result.ErrorMessage))
            {
                ViewBag.Result = result.Result;
            }
            else
            {
                ViewBag.Result = result.ErrorMessage;
            }
            
            HttpContext.Session.Set("calc", calc);
            
            return View();
        }

        public IActionResult History(string filter)
        {
            Calculator calc = HttpContext.Session.Get<Calculator>("calc");
            
            if (calc != null)
            {
                if (filter == null)
                {
                    ViewBag.History = calc.getHistory();
                }
            }
            else
            {
                ViewBag.History = new List<string>()
                {
                    "No operations have been performed yet."
                };
            }

            return View();
        }

        public IActionResult Privacy()
        {
            
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
