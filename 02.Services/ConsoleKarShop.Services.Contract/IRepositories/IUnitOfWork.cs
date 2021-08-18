using System;

namespace ConsoleKarShop.Services.Contract.IRepositories
{
    public interface IUnitOfWork:IDisposable
    {
       ITeacherRepository TeacherRepository { get; }
        void Save();
    }
}