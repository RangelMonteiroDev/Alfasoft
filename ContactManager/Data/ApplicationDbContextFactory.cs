using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace ContactManager.Data
{
   public sealed class ApplicationDbContextFactory
    : IDesignTimeDbContextFactory<ApplicationDbContext>
{
    public ApplicationDbContext CreateDbContext(string[] args)
    {
        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseMySql(
                "Server=recruitment.alfasoft.pt;Port=3306;DataBase=rangelmonteiro-net;Uid=rangelmonteiro-net;Pwd=gNNOsOAhdFQolqn;",
                new MySqlServerVersion(new Version(10, 6)))
            .Options;

        return new ApplicationDbContext(options);
    }
}
}