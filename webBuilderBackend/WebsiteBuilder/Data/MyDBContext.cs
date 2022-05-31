using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebsiteBuilder.Models.UserTemplateModel.CreateUserTemplate;

namespace WebsiteBuilder.Data
{
    public class MyDBContext:DbContext
    {
        public MyDBContext(DbContextOptions<MyDBContext> options) : base(options) { }

        public DbSet<CreateUserTemplateModel> user { get; set; }
        public DbSet<TemplateModel> usertemplate { get; set; }
    }
}
