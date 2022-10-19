using ARMiniCore.Data.Models;
using ARMiniCore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

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

            miniCoreModel = calcularFechas(DateTime.Now.Date);
             
            return View(miniCoreModel);
        }

        [HttpPost]
        public IActionResult Index(DateTime fechaSeleccionada)
        {
            
            MiniCoreModel miniCoreModel = new MiniCoreModel();
            miniCoreModel = calcularFechas(fechaSeleccionada);
            return View(miniCoreModel);
        }

        private MiniCoreModel calcularFechas(DateTime fechaCalcular)
        {
            MiniCoreModel miniCoreModel = new MiniCoreModel();

            List<UsuarioPase> usuarioPasesVigentes = new List<UsuarioPase>();

            usuarioPasesVigentes = (from up in _context.UsuarioPase
                                    join us in _context.Usuario on up.UsuarioId equals us.UsuarioId
                                    join pa in _context.Pase on up.PaseId equals pa.PaseId
                                    where DateTime.Compare(fechaCalcular, up.FechaExpiracion) <= 0
                                    && DateTime.Compare(fechaCalcular, up.FechaCompra) >= 0
                                    select new UsuarioPase
                                    {
                                        FechaExpiracion = up.FechaExpiracion,
                                        FechaCompra = up.FechaCompra,
                                        PaseId = up.PaseId,
                                        UsuarioId = up.UsuarioId,
                                        Usuario = us,
                                        Pase = new Pase
                                        {
                                            PaseId = pa.PaseId,
                                            TipoPase = pa.TipoPase,
                                            Costo = pa.Costo,
                                            Pases = pa.Pases,
                                            CostoPase = pa.CostoPase
                                        }
                                    }).ToList();

            var usuariosVigentes = (from us in _context.Usuario.ToList()
                                    join up in usuarioPasesVigentes on us.UsuarioId equals up.UsuarioId
                                    select us).Distinct().ToList();

            var pases = _context.Pase.ToList();


            foreach (var item in usuarioPasesVigentes)
            {
                var paseComprado = pases.Where(p => p.PaseId == item.PaseId).FirstOrDefault();
                if (paseComprado != null)
                {
                    var numeroPases = paseComprado.Pases;
                    var numeroPasesConsumidos = (fechaCalcular - item.FechaCompra).Days;
                    item.Pase.Pases = numeroPases - numeroPasesConsumidos;
                }
            }

            miniCoreModel.Usuarios = usuariosVigentes;
            miniCoreModel.Pases = pases;
            miniCoreModel.UsuarioPases = usuarioPasesVigentes;

            return miniCoreModel;
        }
    }
}
