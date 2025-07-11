using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebAPI.Models;

namespace WebAPI
{
    //correção realizada para web api 5.2.9 não estava sendo compativel para instalação do entity 
    public class GTIDbContext:DbContext
    {
        public GTIDbContext() : base("connectionGTI") { }

        public DbSet<Cliente> Clientes { get; set; }

    }
}