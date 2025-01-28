using System.Diagnostics;
using MemberModule.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging; // Ensure this namespace is included
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

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

        public async Task<IActionResult> Members()
        {
            var allMembers = await _context.Members.ToListAsync();
            return View(allMembers);
        }

        public async Task<IActionResult> CreateEditMemberForm(int? id)
        {
            if(id != null)
            {
                var memberInDb = await _context.Members.FindAsync(id);
                if(memberInDb == null)
                {
                    return NotFound();
                }
                return View(memberInDb);
            }


            return View();
        }

        public async Task<IActionResult> DeleteMember(int id)
        {
            var memberInDb = await _context.Members.FindAsync(id);
            if(memberInDb == null)
            {
                return NotFound();
            }
            return View(memberInDb);
        }

        [HttpPost, ActionName("DeleteMember")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteMemberConfirmed(int id)
        {
            var memberInDb = await _context.Members.FindAsync(id);
            if(memberInDb == null)
            {
                return NotFound();
            }
            _context.Members.Remove(memberInDb);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Members));
        }

        public async Task<IActionResult> CreateEditMember(Member model)
        {
            if(ModelState.IsValid)
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
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Members));
            }

            var modelStateErrors = ModelState.Values.SelectMany(v => v.Errors);
            foreach (var error in modelStateErrors)
            {
                _logger.LogError(error.ErrorMessage);
            }

            return View(model);
        }

        public IActionResult About()
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
