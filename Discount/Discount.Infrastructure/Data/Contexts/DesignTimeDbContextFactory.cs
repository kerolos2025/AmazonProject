using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Discount.Infrastructure.Data.Contexts
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {

            var optionBuilder = new DbContextOptionsBuilder<AppDbContext>();
            optionBuilder.UseSqlServer("Data Source=DESKTOP-AAOESE8\\SQLEXPRESS;Initial Catalog=DiscountDB;Integrated Security=True;Trust Server Certificate=True;Connection Timeout=60;");
            return new AppDbContext(optionBuilder.Options);



        }
    }
}
