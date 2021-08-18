using ConsoleKarShop.Services.Contract.IRepositories;

namespace ConsoleKarShop.Infrastructures.EF.Repositories
{
    public class UnitOfWork:IUnitOfWork
    {
        private readonly ConsoleKarStoreContext _context;

        public UnitOfWork(ConsoleKarStoreContext context)
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