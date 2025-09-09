using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ISOTEP_WEB.Models
{
    public class EscuelaNMSCarrera
    {
        [Key]
        public int ID { get; set; }

        [ForeignKey("EscuelaNMS")]  
        public int EscuelaNMSID { get; set; }
        public EscuelaNMS EscuelaNMS { get; set; } 

        [ForeignKey("Carrera")]  
        public int CarreraID { get; set; }
        public Carrera Carrera { get; set; }  

    }
}