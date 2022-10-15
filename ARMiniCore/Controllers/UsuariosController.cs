using ARMiniCore.Data.Models;
using Microsoft.AspNetCore.Mvc;

namespace ARMiniCore.Controllers
{
    public class UsuariosController : Controller
    {
        private DataBaseContext _context;

        public UsuariosController(DataBaseContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var usuarios = _context.Usuario.ToList();
            return View(usuarios);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Usuario nuevoUsuario)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Error = "Error";
                return View(nuevoUsuario);
            }
            _context.Usuario.Add(nuevoUsuario);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
