using ISOTEP_WEB.Models.SOTEP_WEB.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ISOTEP_WEB.Models
{
    public class Horario
    {
        [Key]
        public int ID { get; set; }

        [ForeignKey("PracticanteEtapaResponsable")]
        public int PracticanteEtapaResponsableID { get; set; }
        public PracticanteEtapaResponsable PracticanteEtapaResponsable { get; set; }

        [Required]
        [StringLength(10)]  
        public string Dia { get; set; }

        [Required]
        public TimeSpan HoraEntrada { get; set; }  

        [Required]
        public TimeSpan HoraSalida { get; set; }

    }
}