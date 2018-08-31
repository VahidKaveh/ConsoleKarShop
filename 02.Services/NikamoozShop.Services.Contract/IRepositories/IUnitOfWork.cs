using System;

namespace NikamoozShop.Services.Contract.IRepositories
{
    public interface IUnitOfWork:IDisposable
    {
       ITeacherRepository TeacherRepository { get; }
        void Save();
    }
}