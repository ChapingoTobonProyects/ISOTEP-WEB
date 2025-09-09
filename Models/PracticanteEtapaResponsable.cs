using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ISOTEP_WEB.Models
{

namespace SOTEP_WEB.Models
    {
        public class PracticanteEtapaResponsable
        {
            [Key]
            public int ID { get; set; }

            [ForeignKey("Etapa")]
            public int EtapaID { get; set; }
            public Etapa Etapa { get; set; }

            [ForeignKey("Practicante")]
            public int PracticanteID { get; set; }
            public Practicante Practicante { get; set; }

            [ForeignKey("Responsable")]
            public int ResponsableID { get; set; }
            public Responsable Responsable { get; set; }

            [Required]
            [StringLength(50)]
            public string Grupo { get; set; }

            [Required]
            [Column(TypeName = "date")]
            public DateTime FechaInicio { get; set; }

            [Required]
            [Column(TypeName = "date")]
            public DateTime FechaTermino { get; set; }

            [Required]
            public int TotalHoras { get; set; }

            [Required]
            [StringLength(20)]
            public string Estatus { get; set; }
        }
}
}