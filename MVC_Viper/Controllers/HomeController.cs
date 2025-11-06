using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC_Viper.Models;
using System.Diagnostics;

namespace MVC_Viper.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ProviderDBContext _context;

        public HomeController(ILogger<HomeController> logger, ProviderDBContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            var programs = _context.Programs.ToList();
            return View(programs);
        }

        // GET: Home/Welcome
        public async Task<IActionResult> Welcome()
        {
            var username = User.Identity.Name;

            var client = await _context.Clients.Include(c => c.User).FirstOrDefaultAsync(c => c.User.Username == username);

            if(client == null)
            {
                return RedirectToAction("Login", "Users");
            }

            var phone = await _context.Phones.Include(p => p.ProgramNameNavigation).FirstOrDefaultAsync(p => p.PhoneNumber == client.PhoneNumber);

            var callHistory = await _context.Calls.Where(c => c.Bills.Any(b => b.PhoneNumber == client.PhoneNumber)).OrderByDescending(c => c.CallId).ToListAsync();

            var latestBill = await _context.Bills.Where(b => b.PhoneNumber ==client.PhoneNumber).OrderByDescending(b => b.BillId).FirstOrDefaultAsync();

            var model = new ClientDashboardViewModel
            {
                PhoneNumber = client.PhoneNumber,
                Program = phone?.ProgramName ?? "Unknown",
                ProgramBenefits = phone?.ProgramNameNavigation?.Benefits,
                ProgramCharge = phone?.ProgramNameNavigation?.Charge ?? 0,
                CallHistory = callHistory,
                CurrentBill = latestBill?.Costs ?? 0
            };
            return View(model);
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
