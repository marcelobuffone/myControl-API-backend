using MBAM.Business.Interfaces;
using MBAM.Business.Interfaces.Repository;
using MBAM.Business.Interfaces.Services;
using MBAM.Business.Models.Archive;
using System;
using System.Threading.Tasks;

namespace MBAM.Business.Services
{
    public class ArchiveService : BaseService, IArchiveService
    {

        private readonly IArchiveRepository _archiveRepository;

        public ArchiveService(IArchiveRepository archiveRepository,
                              IMessenger messenger) : base(messenger)
        {
            _archiveRepository = archiveRepository;
        }

        public async Task<bool> Add(Archive archive)
        {
            if (!ExecuteValidation(new ArchiveValidation(), archive)) return false;
            await _archiveRepository.Add(archive);
            return true;
        }

        public async Task<bool> Update(Archive archive)
        {
            if (!ExecuteValidation(new ArchiveValidation(), archive)) return false;

            await _archiveRepository.Update(archive);
            return true;
        }

        public async Task<bool> Delete(Guid id)
        {
            await _archiveRepository.Delete(id);
            return true;
        }

        public void Dispose()
        {
            _archiveRepository?.Dispose();
        }

    }
}
