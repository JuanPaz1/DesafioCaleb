using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
namespace DesafioCaleb.Models
{
    public class contexto:DbContext
    {
        public DbSet <pessoas> Pessoas { get; set; } 
    }
}