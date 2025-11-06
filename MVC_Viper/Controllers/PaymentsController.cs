using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC_Viper.Models;

namespace MVC_Viper.Controllers
{
    public class PaymentsController : Controller
    {
        private readonly ProviderDBContext _context;

        public PaymentsController(ProviderDBContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> PayBill()
        {
            var username = User.Identity.Name;
            var client = await _context.Clients.Include(c => c.User).FirstOrDefaultAsync(c => c.User.Username == username); 

            if (client == null) 
            {
                return RedirectToAction("Login", "Users");
            }

            var bill = await _context.Bills.Where(b => b.PhoneNumber == client.PhoneNumber).OrderByDescending(b => b.BillId).FirstOrDefaultAsync();

            if(bill == null || bill.Costs == 0)
            {
                TempData["Message"] = "No outstanding bill.";
                return RedirectToAction("Welcome", "Home");
            }

            bill.Costs = 0;
            await _context.SaveChangesAsync();

            TempData["Message"] = "Payment Successful!.";
            return RedirectToAction("Welcome", "Home");
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
