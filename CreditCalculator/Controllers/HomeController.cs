using Kalkulator.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using Microsoft.Extensions.Hosting;

namespace Kalkulator.Controllers
{
    public interface ICreditCalculationService
    {
        List<PaymentResultModel> CalculatePayments(CreditInformationModel creditInformation);
    }

    public class CreditCalculationService : ICreditCalculationService
    {
        public List<PaymentResultModel> CalculatePayments(CreditInformationModel creditInformation)
        {
            decimal balance = creditInformation.Sum;
            List<PaymentResultModel> results = new List<PaymentResultModel>();
            for (int j = 0; j < creditInformation.Time; j++)
            {
                PaymentResultModel result = CreateResultModel(creditInformation, j, ref balance);
                results.Add(result);
            }
            return results;
        }

        private PaymentResultModel CreateResultModel(CreditInformationModel creditInformation, int index, ref decimal balance)
        {
            PaymentResultModel result = new PaymentResultModel();
            result.Date = DateTime.Now.AddDays(index + 1).ToString("d MMMM yyyy") + " г.";
            result.ID = index + 1;
            decimal i = creditInformation.Rate / 12 / 100;
            decimal power = (decimal)Math.Pow((double)(1 + i), creditInformation.Time);
            decimal сoef = (i * power) / (power - 1);
            decimal total = сoef * creditInformation.Sum;
            decimal percent = balance / 12 / 100 * creditInformation.Rate;
            decimal part = total - percent;
            balance -= part;
            result.Balance = balance;
            result.Percent = percent;
            result.Body = part;
            return result;
        }
    }

    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICreditCalculationService _creditCalculationService;

        public HomeController(ILogger<HomeController> logger, ICreditCalculationService creditCalculationService)
        {
            _logger = logger;
            _creditCalculationService = creditCalculationService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        public IActionResult Index(CreditInformationModel creditInformation)
        {
            if (ModelState.IsValid)
            {
                var results = _creditCalculationService.CalculatePayments(creditInformation);
                decimal totalOverpaid = results.Sum(x => x.Percent);
                TempData["totalOverpaid"] = totalOverpaid;
                return View("Results", results);
            }
            return View(creditInformation);
        }
    }
}