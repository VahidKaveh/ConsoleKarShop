using Microsoft.EntityFrameworkCore;
using ConsoleKarShop.Services.Contract.IRepositories;
using ConsoleKarShop.Domain.Entites;

namespace ConsoleKarShop.Infrastructures.EF.Repositories
{
    public class TeacherRepository:Repository<Teacher>,ITeacherRepository
    {
        public TeacherRepository(DbContext context) : base(context)
        {
        }
    }
}