using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Model
{
    public class ApplicationDbConnect:DbContext
    {
        public ApplicationDbConnect(DbContextOptions<ApplicationDbConnect>options ):base(options)
        {
                
        }

        public DbSet<Book>  Book { get; set; }
    }
}
