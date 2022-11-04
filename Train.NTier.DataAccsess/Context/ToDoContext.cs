using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Train.NTier.DataAccsess.Confugiration;
using Train.NTier.Entity.Concrete;

namespace Train.NTier.DataAccsess.Context
{
    public class ToDoContext:DbContext
    {
        public ToDoContext(DbContextOptions<ToDoContext> options):base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new WorkConfugiration());
        }
        DbSet<Work> Works { get; set; }
    }
}
