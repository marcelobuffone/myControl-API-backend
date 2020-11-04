using MBAM.Business.Models;
using MBAM.Business.Models.Payment;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MBAM.Business.Interfaces.Repository
{
    public interface IPaymentRepository : IRepository<Payment>
    {
        Task<List<Payment>> GetAllActives();
    }
}
