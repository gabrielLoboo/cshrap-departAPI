using Dep.WebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace Dep.WebAPI.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Departamento> Departamentos { get; set; }
        public DbSet<Funcionario> Funcionarios { get; set; }
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Password=180105;Persist Security Info=True;User ID=sa;Initial Catalog=DepartApp;Data Source=DESKTOP-BFHMBTJ;TrustServerCertificate=True");
        }
    }

}
