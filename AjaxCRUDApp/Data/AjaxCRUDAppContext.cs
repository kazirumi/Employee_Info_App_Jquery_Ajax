using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AjaxCRUDApp.Models;

    public class AjaxCRUDAppContext : DbContext
    {
        public AjaxCRUDAppContext (DbContextOptions<AjaxCRUDAppContext> options)
            : base(options)
        {
        }

        public DbSet<AjaxCRUDApp.Models.Employee> Employee { get; set; }
    }
