using MBAM.Business.Interfaces.Repository;
using MBAM.Business.Models.Payment;
using MBAM.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MBAM.Data.Repository
{
    public class PaymentRepository : Repository<Payment>, IPaymentRepository
    {
        public PaymentRepository(MyControlDbContext context) : base(context) { }

        public async Task<List<Payment>> GetAllActives()
        {
            return await Db.Payments.AsNoTracking()
                .Where(c => c.IsActive).OrderByDescending(e => e.CreateDate).ToListAsync();
        }
    }
}
