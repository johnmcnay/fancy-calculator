using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using CalculatorCore;
using Microsoft.AspNetCore.Http;
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

        public IActionResult Calculator()
        {
            string name = HttpContext.Session.GetString("name");

            if (String.IsNullOrWhiteSpace(name))
            {
                HttpContext.Session.SetString("name", "unknown");
                ViewBag.Name = "unknown";
                return View();
            }

            ViewBag.Name = name;
            ViewBag.Result = TempData["result"];

            return View();
        }

        [HttpPost]
        public IActionResult SetName(string name)
        {
            HttpContext.Session.SetString("name", String.IsNullOrWhiteSpace(name) ? "unknown" : name);

            return RedirectToAction("Calculator");

        }

        [HttpPost]
        public IActionResult Calculator(string calculatorInput)
        {

            Calculator calc = HttpContext.Session.Get<Calculator>("calc");
            
            if (calc == null)
            {
                calc = new Calculator();
            }

            EvaluationResult result = calc.Evaluate(calculatorInput);
            
            if (String.IsNullOrEmpty(result.ErrorMessage))
            {
                TempData["result"] = result.Result.ToString();
            }
            else
            {
                TempData["result"] = $"<span style='color: red;'>{result.ErrorMessage}</span>";
            }
            
            HttpContext.Session.Set("calc", calc);
            
            return RedirectToAction("Calculator");
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
                else
                {
                    ViewBag.History = (from entry in calc.getHistory()
                                      where entry[0].Contains(filter)
                                      select entry).ToList();
                }
            }
            else
            {
                ViewBag.History = new List<List<string>>()
                {
                    new List<string>()
                    {
                        "No operations have been performed yet",
                        "1"
                    }
                    
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
