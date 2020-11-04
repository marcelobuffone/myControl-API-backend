using MBAM.Business.Interfaces.Repository;
using MBAM.Business.Models.Archive;
using MBAM.Data.Context;

namespace MBAM.Data.Repository
{
    public class ArchiveRepository : Repository<Archive>, IArchiveRepository
    {
        public ArchiveRepository(MyControlDbContext context) : base(context) { }
    }
}
