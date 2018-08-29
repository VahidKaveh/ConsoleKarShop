using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace NikamoozShop.Infrastructures.EF
{
    public class NikamoozContextBuilder:IDesignTimeDbContextFactory<NikamoozStoreContext>
    {
        public NikamoozStoreContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder();
            builder.UseSqlServer(@"server=(localdb)\ProjectsV13;database=NikamoozShopDb;integrated security=true");
            return new NikamoozStoreContext(builder.Options);
            
        }
    }
}