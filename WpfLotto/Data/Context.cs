using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WpfLotto.Models;

namespace WpfLotto.Data
{
    public class Context : DbContext
    {
        public DbSet<Sorsolas> Sorsolasok { get; set; }
        
        public Context()
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=LottoSzimulacio;Trusted_Connection=True;");
        }
    }
}
