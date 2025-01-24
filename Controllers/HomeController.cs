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
            var allMembers = _context.Members.ToList();
            return View(allMembers);
        }

        public IActionResult CreateEditMember(int? id)
        {
            if(id != null)
            {
                var memberInDb = _context.Members.FirstOrDefault(member => member.Id == id);
                return View(memberInDb);
            }


            return View();
        }

        public IActionResult DeleteMember(int id)
        {
            var memberInDb = _context.Members.FirstOrDefault(member => member.Id == id);
            _context.Members.Remove(memberInDb);
            _context.SaveChanges();
            return RedirectToAction("Members");
        }

        public IActionResult CreateEditMemberForm(Member model)
        {
            if(model.Id == 0)
            {
                //create
                _context.Members.Add(model);
            }
            else
            {

                _context.Members.Update(model);
            }

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
