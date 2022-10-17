using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARMiniCore.Data.Models
{
    public class Pase
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PaseId { get; set; }
        public string TipoPase { get; set; }
        public double Costo { get; set; }
        public int Pases { get; set; }
        public double CostoPase { get; set; }

        public List<UsuarioPase> UsuarioPases { get; set; }
    }
}
