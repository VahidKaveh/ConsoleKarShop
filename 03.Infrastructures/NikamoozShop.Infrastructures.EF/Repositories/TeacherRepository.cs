using Microsoft.EntityFrameworkCore;
using NikamoozShop.Services.Contract.IRepositories;
using NikamozzShop.Domain.Entites;

namespace NikamoozShop.Infrastructures.EF.Repositories
{
    public class TeacherRepository:Repository<Teacher>,ITeacherRepository
    {
        public TeacherRepository(DbContext context) : base(context)
        {
        }
    }
}