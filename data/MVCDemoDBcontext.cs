using Microsoft.EntityFrameworkCore;
using WebApplication2.Models.Domain;
namespace WebApplication2.data
{
    public class MVCDemoDBcontext :DbContext
    {
        public MVCDemoDBcontext(DbContextOptions <MVCDemoDBcontext> options) :base(options)
        { }
        public DbSet<Facture> Facture{get; set; }
      
    }
}
