using Microsoft.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EzlynxProductApp.Models
{
    public class ModelsContext : DbContext
    {

        public DbSet<Product> Products { get; set; }
    }
}
