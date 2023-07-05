using DataProtectInServer.Models;
using DataProtectInServer.Security;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DataProtectInServer.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IHostEnvironment _host;

        public HomeController(ILogger<HomeController> logger, IHostEnvironment host)
        {
            _logger = logger;
            _host = host;
        }

        public IActionResult Index()
        {
            string key = "Bu string çok gizli bilgiler içeriyor";
            DataProtector dataProtector = new DataProtector(_host.ContentRootPath + @"\secret.halk");
            int length = dataProtector.EncryptedData(key);

            string decrypted = dataProtector.DecryptData(length);
            ViewBag.Decrypted = decrypted;
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