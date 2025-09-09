using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ISOTEP_WEB.Models
{
    public class EscuelaNMS
    {

        [Key]
        public int ID { get; set; }

        [Required]
        [StringLength(100)]
        public string Nombre { get; set; }

        [StringLength(200)]
        public string Ubicacion { get; set; }

        [StringLength(100)]
        public string Responsable { get; set; }

        [StringLength(100)]
        public string TituloResponsable { get; set; }

        [StringLength(50)]
        public string CCT { get; set; }
    }

    }
