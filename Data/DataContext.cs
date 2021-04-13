using crud_apirest_agenda.Models;
using Microsoft.EntityFrameworkCore;


namespace crud_apirest_agenda.Data{
    public class DataContext : DbContext{

        public DataContext(DbContextOptions<DataContext> options) : base(options){

        }

        public DbSet<Contato> Contato { get; set; }

    }
}