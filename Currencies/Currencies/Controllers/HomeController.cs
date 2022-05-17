using Currencies.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;

namespace Currencies.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IWebHostEnvironment Environment;

        public HomeController(ILogger<HomeController> logger, IWebHostEnvironment environment)
        {
            _logger = logger;
            Environment = environment;
        }

        public IActionResult Index()
        {
            List<EmployeeModel> employees = new List<EmployeeModel>();


            XmlDocument doc = new XmlDocument();
            doc.Load(string.Concat(this.Environment.WebRootPath, "/Employee.xml"));

            foreach (XmlNode node in doc.SelectNodes("./Employees/Employee"))
            {
                employees.Add(new EmployeeModel
                {
                    CurrencyCode = int.Parse(node["CurrencyCode"].InnerText),
                    CurrencyCodeL = node["CurrencyCodeL"].InnerText,
                    Amount = node["Amount"].InnerText

                });
            }
            return View(employees);
        }
    }
}
