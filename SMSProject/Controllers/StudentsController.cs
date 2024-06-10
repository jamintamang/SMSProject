using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SMSProject.Data;
using SMSProject.Models;
using System.Linq;
using System.Threading.Tasks;

namespace SMSProject.Controllers
{
    public class StudentsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<StudentsController> _logger;

        public StudentsController(ApplicationDbContext context, ILogger<StudentsController> logger)
        {
            _context = context;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var students = await _context.ApplicationUsers.ToListAsync();
            return View(students);
        }

        [HttpGet]
        public IActionResult Add()
        {
            ApplicationUser applicationUser = new ApplicationUser();
            return View(applicationUser);
        }

        [HttpPost]
        public async Task<IActionResult> Add(ApplicationUser user)
        {
            if (ModelState.IsValid)
            {
                _context.Add(user);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(user);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            var student = await _context.ApplicationUsers.FindAsync(id);
            if (student == null)
            {
                return NotFound();
            }
            return View(student);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ApplicationUser user)
        {
            if (ModelState.IsValid)
            {
                var student = await _context.ApplicationUsers.FindAsync(user.Id);
                if (student == null)
                {
                    return NotFound();
                }

                student.Name = user.Name;
                student.BOD = user.BOD;
                student.Email = user.Email;
                student.PhoneNumber = user.Number;
                student.Course = user.Course;

                _context.Update(student);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(user);
        }

        [HttpPost]
        public async Task<IActionResult> Remove(string id)
        {
            var student = await _context.ApplicationUsers.FindAsync(id);
            if (student == null)
            {
                return NotFound();
            }

            _context.Remove(student);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }                                               

        [HttpGet]
        public async Task<IActionResult> Detail(string id)
        {
            var student = await _context.ApplicationUsers.FindAsync(id);
            if (student == null)
            {
                return NotFound();
            }
            return View(student);
        }
    }
}
