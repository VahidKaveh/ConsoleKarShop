using NikamoozShop.Services.Contract.IRepositories;

namespace NikamoozShop.Infrastructures.EF.Repositories
{
    public class UnitOfWork:IUnitOfWork
    {
        private readonly NikamoozStoreContext _context;

        public UnitOfWork(NikamoozStoreContext context)
        {
            _context = context;
            TeacherRepository= new TeacherRepository(_context);
        }

        public ITeacherRepository TeacherRepository { get;}
        public void Save()
        {
            _context.SaveChanges();
        }
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}