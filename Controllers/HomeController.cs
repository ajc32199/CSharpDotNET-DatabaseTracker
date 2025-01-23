using System.Diagnostics;
using MemberModule.Models;
using Microsoft.AspNetCore.Mvc;

namespace MemberModule.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly MembersDBContext _context;

        public HomeController(ILogger<HomeController> logger, MembersDBContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Members()
        {
            //Next step is here, video at 35:27
            return View();
        }

        public IActionResult CreateEditMember()
        {
            return View();
        }

        public IActionResult CreateEditMemberForm(Member model)
        {
            _context.Members.Add(model);
            _context.SaveChanges();
            return RedirectToAction("Members");
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
