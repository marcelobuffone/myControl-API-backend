using MBAM.Business.Models.Archive;
using System;
using System.Threading.Tasks;

namespace MBAM.Business.Interfaces.Services
{
    public interface IArchiveService : IDisposable
    {
        Task<bool> Add(Archive archive);
        Task<bool> Update(Archive archive);
        Task<bool> Delete(Guid id);
    }
}
