using ISOTEP_WEB.Models;
using ISOTEP_WEB.Models.SOTEP_WEB.Models;
using System.ComponentModel.DataAnnotations.Schema; 
using System.Data.Entity;

namespace ISOTEP_WEB.Models
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext() : base("name=DefaultConnection") { }

        public DbSet<EscuelaNMS> EscuelasNMS { get; set; }
        public DbSet<Carrera> Carreras { get; set; }
        public DbSet<EscuelaNMSCarrera> EscuelaNMSCarreras { get; set; }
        public DbSet<Practicante> Practicantes { get; set; }
        public DbSet<Etapa> Etapas { get; set; }
        public DbSet<PracticanteEtapaResponsable> PracticanteEtapaResponsable { get; set; }
        public DbSet<Area> Areas { get; set; }
        public DbSet<Responsable> Responsables { get; set; }
        public DbSet<Horario> Horarios { get; set; }

       

    }
}