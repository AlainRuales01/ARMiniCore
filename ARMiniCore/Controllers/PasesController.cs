using ARMiniCore.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ARMiniCore.Controllers
{
    public class PasesController : Controller
    {
        private DataBaseContext _context;

        public PasesController(DataBaseContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var pases = _context.Pase.ToList();
            return View(pases);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Pase nuevoPase)
            {
            _context.Pase.Add(nuevoPase);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
