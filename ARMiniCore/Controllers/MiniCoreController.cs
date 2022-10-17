using ARMiniCore.Data.Models;
using ARMiniCore.Models;
using Microsoft.AspNetCore.Mvc;

namespace ARMiniCore.Controllers
{
    public class MiniCoreController : Controller
    {
        private DataBaseContext _context;

        public MiniCoreController(DataBaseContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            MiniCoreModel miniCoreModel = new MiniCoreModel();
            miniCoreModel.Usuarios = _context.Usuario.ToList();
            miniCoreModel.Pases = _context.Pase.ToList();
            miniCoreModel.UsuarioPases = _context.UsuarioPase.ToList();
            return View(miniCoreModel);
        }
    }
}
