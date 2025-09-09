using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ISOTEP_WEB.Models
{
    public class Practicante
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        public string ApellidoPaterno { get; set; }

        [Required]
        [StringLength(50)]
        public string ApellidoMaterno { get; set; }

        [Required]
        [StringLength(100)]
        public string Nombre { get; set; }

        [Required]
        [StringLength(20)]
        public string Matricula { get; set; }

        [ForeignKey("EscuelaNMSCarrera")]
        public int EscuelaNMSCarreraID { get; set; }
        public virtual EscuelaNMSCarrera EscuelaNMSCarrera { get; set; }

        [Required]
        [StringLength(20)]
        public string Turno { get; set; }

        [Required]
        [StringLength(18)]
        public string CURP { get; set; }

        [Required]
        [StringLength(15)]
        public string TelefonoAlumno { get; set; }

        [Required]
        [StringLength(15)]
        public string TelefonoTutor { get; set; }

        [Required]
        [EmailAddress]
        public string Correo_electronico { get; set; }

        [Required]
        public string Domicilio { get; set; }

        [Required]
        [StringLength(20)]
        public string NSS { get; set; }

        [Required]
        [StringLength(10)]
        public string Genero { get; set; }

        [Required]
        public decimal Promedio { get; set; }

    }
}