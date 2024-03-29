﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace ConsoleKarShop.Infrastructures.EF
{
    public class ConsoleKarContextBuilder:IDesignTimeDbContextFactory<ConsoleKarStoreContext>
    {
        public ConsoleKarStoreContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder();
            builder.UseSqlServer(@"server=(localdb)\MSSQLLocalDB;database=ConsoleKarShopDb;integrated security=true");
            return new ConsoleKarStoreContext(builder.Options);
            
        }
    }
}