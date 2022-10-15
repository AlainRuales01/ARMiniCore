using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARMiniCore.Data.Models
{
    public class UsuarioPase
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UsuarioPaseId { get; set; }
        public int UsuarioId { get; set; }
        public int PaseId { get; set; }
        public DateTime fechaCompra{ get; set; }
        public DateTime fechaExpiracion { get; set; }
        public virtual Usuario Usuario { get; set; }
        public virtual Pase Pase{ get; set; }
    }
}
