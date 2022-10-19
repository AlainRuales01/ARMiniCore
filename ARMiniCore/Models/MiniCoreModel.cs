using ARMiniCore.Data.Models;

namespace ARMiniCore.Models
{
    public class MiniCoreModel
    {
        public List<Usuario> Usuarios { get; set; }
        public List<Pase> Pases { get; set; }
        public List<UsuarioPase> UsuarioPases { get; set; }
        public DateTime FechaSeleccionada { get; set; }

    }
}
