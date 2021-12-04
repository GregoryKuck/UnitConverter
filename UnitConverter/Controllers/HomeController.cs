using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Diagnostics;
using UnitConverter.Models;

namespace UnitConverter.Controllers
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
            //string x = "(10 - 32) / 1.8";
            //var y = Evaluate(x);
            
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

        public static decimal Evaluate(string expression)
        {
            DataTable table = new DataTable();
            table.Columns.Add("myExpression", string.Empty.GetType(), expression);
            DataRow row = table.NewRow();
            table.Rows.Add(row);
            return decimal.Parse((string)row["myExpression"]);
        }

    }
}