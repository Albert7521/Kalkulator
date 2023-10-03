using Kalkulator.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Kalkulator.Controllers
{
    public interface IPaymentService
    {
        PaymentResultModel CreatePaymentResult(CreditInformationModel creditInformation, int paymentNumber);
        IList<PaymentResultModel> CreatePaymentPlan(CreditInformationModel creditInformation);
    }

    public class PaymentService : IPaymentService
    {
        public PaymentResultModel CreatePaymentResult(CreditInformationModel creditInformation, int paymentNumber, ref decimal balance)
        {
            PaymentResultModel result = new PaymentResultModel
            {
                Date = DateTime.Now.AddDays(paymentNumber + 1).ToString("d MMMM yyyy") + " г.",
                ID = paymentNumber + 1
            };

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

        public IList<PaymentResultModel> CreatePaymentPlan(CreditInformationModel creditInformation)
        {
            decimal balance = creditInformation.Sum;
            List<PaymentResultModel> results = new List<PaymentResultModel>();
            for (int j = 0; j < creditInformation.Time; j++)
            {
                PaymentResultModel result = CreatePaymentResult(creditInformation, j, ref balance);
                results.Add(result);
            }
            return results;
        }

        public PaymentResultModel CreatePaymentResult(CreditInformationModel creditInformation, int paymentNumber)
        {
            throw new NotImplementedException();
        }
    }

    public class HomeController : Controller
    {
        private readonly IPaymentService _paymentService;
        private readonly ILogger<HomeController> _logger;

        public HomeController(IPaymentService paymentService, ILogger<HomeController> logger)
        {
            _paymentService = paymentService;
            _logger = logger;
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
                IList<PaymentResultModel> results = _paymentService.CreatePaymentPlan(creditInformation);

                decimal totalOverpaid = results.Sum(x => x.Percent);
                TempData["totalOverpaid"] = totalOverpaid;

                return View("Results", results);
            }
            return View(creditInformation);
        }
    }
}