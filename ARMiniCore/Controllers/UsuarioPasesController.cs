using ARMiniCore.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ARMiniCore.Controllers
{
    public class UsuarioPasesController : Controller
    {

        private DataBaseContext _context;

        public UsuarioPasesController(DataBaseContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var usuarioPases = (from up in _context.UsuarioPase
                                join us in _context.Usuario on up.UsuarioId equals us.UsuarioId
                                join pa in _context.Pase on up.PaseId equals pa.PaseId
                                select new UsuarioPase
                                {
                                    UsuarioId = up.UsuarioId,
                                    PaseId = up.PaseId,
                                    FechaCompra = up.FechaCompra,
                                    FechaExpiracion = up.FechaExpiracion,
                                    Usuario = us,
                                    Pase = pa
                                }).ToList();

            return View(usuarioPases);
        }

        public IActionResult Create()
        {
            ViewBag.UsuarioId = new SelectList(_context.Usuario, "UsuarioId", "Nombre");
            ViewBag.PaseId = new SelectList(_context.Pase, "PaseId", "TipoPase");
            return View();
        }

        [HttpPost]
        public IActionResult Create(UsuarioPase nuevoUsuarioPase)
        {
            var nuevoUsuarioPaseId = nuevoUsuarioPase.PaseId;
            var tipoPase = _context.Pase.Where(p => p.PaseId == nuevoUsuarioPaseId).FirstOrDefault();
            if (tipoPase != null)
            {
                var fechaCompra = nuevoUsuarioPase.FechaCompra;
                var fechaExpiracion = fechaCompra.AddDays(tipoPase.Pases);
                nuevoUsuarioPase.FechaExpiracion = fechaExpiracion;
                _context.UsuarioPase.Add(nuevoUsuarioPase);
                _context.SaveChanges();
            }
            
            return RedirectToAction("Index");
        }
    }
}
